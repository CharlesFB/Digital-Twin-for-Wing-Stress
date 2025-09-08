using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Statistics
{
    public class LineGraphTest : MonoBehaviour
    {
        private float[] mocklist = {
                121.796f,121.456f,121.439f,121.242f,120.914f,120.920f,120.676f,120.449f,120.580f,120.544f,120.384f,120.366f,120.473f,120.389f,120.693f,120.854f,120.872f,121.111f,121.289f,121.582f,121.880f,122.178f,122.315f,122.583f,122.744f,122.857f,123.173f,123.215f,123.656f,123.924f,124.186f,124.502f,124.788f,124.973f,125.307f,125.712f,126.231f,126.380f,126.415f,126.565f,127.083f,127.262f,127.435f,127.441f,127.399f,127.316f,127.369f,127.000f,126.910f,126.821f,126.511f,126.243f,126.022f,125.927f,125.742f,125.510f,125.563f,125.587f,125.653f,125.629f,125.659f,125.664f,125.611f,125.474f,125.480f,125.635f,125.492f,125.498f,125.450f,125.545f,125.462f,125.152f,125.247f,124.949f,125.235f,125.426f,125.313f,125.468f,125.539f,125.706f,125.915f,126.165f,126.410f,126.791f,127.065f,127.524f,127.643f,127.840f,127.876f,128.078f,128.138f,127.900f,127.858f,127.536f,127.345f,127.161f,126.934f,126.868f,126.487f,126.201f
            };
        private int imock = 0;

        float[] SliceFloatArray(float[] source, int startIndex, int length)
        {
            // 边界检查
            if (source == null)
                throw new System.ArgumentNullException("源数组不能为空");

            if (startIndex < 0 || startIndex >= source.Length)
                return null;

            // 计算实际可以截取的长度，避免越界
            int actualLength = Mathf.Min(length, source.Length - startIndex);

            // 创建新的数组并复制数据
            float[] result = new float[actualLength];
            System.Array.Copy(source, startIndex, result, 0, actualLength);

            return result;
        }


        private interface IColorPick
        {
            Color Color { get; }
        }

        private enum Type
        {
            Mock,
            Function,
            Error
        }

        [Serializable]
        private class MockLine : IList<Vector2>, IColorPick
        {
            [FormerlySerializedAs("Data")] [SerializeField]
            private List<Vector2> data;

            [FormerlySerializedAs("Color")] [SerializeField]
            private Color color;

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<Vector2> GetEnumerator() => data.GetEnumerator();

            public void Add(Vector2 item) => data.Add(item);

            public void Clear() => data.Clear();

            public bool Contains(Vector2 item) => data.Contains(item);

            public void CopyTo(Vector2[] array, int arrayIndex) => data.CopyTo(array, arrayIndex);

            public bool Remove(Vector2 item) => data.Remove(item);

            public int Count => data.Count;
            public bool IsReadOnly => ((IList<Vector2>)data).IsReadOnly;
            public int IndexOf(Vector2 item) => data.IndexOf(item);

            public void Insert(int index, Vector2 item) => data.Insert(index, item);

            public void RemoveAt(int index) => data.RemoveAt(index);

            public Vector2 this[int index]
            {
                get => data[index];
                set => data[index] = value;
            }

            public Color Color => color;
        }

        [Serializable]
        private class FunctionLine : IColorPick
        {
            public List<float> xValues;
            [SerializeField] private Color color;

            public Color Color => color;
        }

        private class ColorPick : IColorPick
        {
            public ColorPick(Color color)
            {
                Color = color;
            }

            public Color Color { get; }
        }

        [SerializeField] private LineGraph lineGraph;
        [SerializeField] private MockLine[] data;
        [SerializeField] private FunctionLine[] funcData;
        [SerializeField] private Type type;
        [SerializeField] private TMP_Dropdown dropdown;
        [SerializeField] private Image lineHighlightPrefab;
        [SerializeField] private bool changeDiscritization;
        private IList<IColorPick> _colorPick;

        private void Start()
        {
            dropdown.ClearOptions();
            var typeNames = Enum.GetNames(typeof(Type)).ToList();
            dropdown.AddOptions(typeNames);
            dropdown.value = (int)type;
            dropdown.RefreshShownValue();
            dropdown.onValueChanged.AddListener(SetType);
            Plot();
            imock = 0;
        }

        private float timer1 = 0.03f;

        private void Update()
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0)
            {
                timer1 = 0.08f;
                if (imock < 100)
                    imock += 1;

                lineGraph.Clear();
                Plot();
            }
           
        }

        private void SetType(int arg0)
        {
            var setType = (Type)arg0;
            type = setType;
            lineGraph.Clear();
            Plot();
        }

        float GenerateRandomFloat(float min, float max, int decimalPlaces)
        {
            float range = max - min;
            float randomValue = UnityEngine.Random.Range(0f, 1f) * range + min;

            // 使用 Mathf.Round 来控制小数位数
            float scale = Mathf.Pow(10, decimalPlaces);
            return Mathf.Round(randomValue * scale) / scale;
        }

        float GenerateMockedLine(float x)
        {
            int dx = (int)Mathf.Floor(x);
            float[] ml = SliceFloatArray(mocklist, imock, 20);
            if (ml == null || ml.Length == 0)
                return 0;
            if (dx < ml.Length)
                return ml[dx];
            else
                return 0;
        }

        public void Plot()
        {
            ILineGraphData selectedData = null;
            switch (type)
            {
                case Type.Mock:
                    selectedData = new SimpleLineGraphData(data);
                    break;
                case Type.Function:
                    selectedData = new FunctionLineGraphData(funcData
                        .Select((functionLine, i) =>
                        {
                            Func<float, float> function = null;
                            switch (i % 3)
                            {
                                case 0:
                                    function = (x) => GenerateMockedLine(x);
                                    break;
                                case 1:
                                    function = (x) => 150 - 1.5f * x;
                                    break;
                                case 2:
                                    function = (x) => 0.05f * x * x + 100;
                                    break;
                                default: throw new NotImplementedException("Function is not created");
                            }

                            return new FunctionLineGraphData.Function(function, functionLine.xValues);
                        })
                        .ToArray()
                    );
                    break;
                case Type.Error:
                    selectedData = new SimpleLineGraphData(
                        new[] { Vector2.one * 0.5f, },
                        new List<Vector2>(), new[] { Vector2.zero, Vector2.up, Vector2.one, Vector2.right, }
                    );
                    break;
                default:
                    throw new ArgumentException("Undefined Type");
            }

            switch (type)
            {
                case Type.Mock:
                    _colorPick = data;
                    break;
                case Type.Function:
                    _colorPick = funcData;
                    break;
                case Type.Error:
                    _colorPick = new List<IColorPick>()
                        { new ColorPick(Color.blue), new ColorPick(Color.black), new ColorPick(Color.red) };
                    break;
                default: throw new ArgumentException("Undefined Type");
            }

            lineGraph.PlotGraph(selectedData, DotCreated, LineCreated, CriticalValuesFound,
                NormalizedLineDotsCalculated);
        }

        private void NormalizedLineDotsCalculated(int lineId, List<Vector2> positions)
        {
            if (lineHighlightPrefab != null)
                lineGraph.DrawHighlight(positions, _colorPick[lineId].Color, lineHighlightPrefab);
        }

        private void CriticalValuesFound(Vector2 min, Vector2 max)
        {
            if (type == Type.Error)
            {
                lineGraph.SetMinMaxOnGraph(Vector2.zero, Vector2.one * 3f);
                lineGraph.Discretization = Vector2.one;
            }
            else if (changeDiscritization)
            {
                lineGraph.Discretization = new Vector2(10, 50);
            }
        }

        private void LineCreated(int lineId, Image line)
        {
            line.color = _colorPick[lineId].Color;
        }

        private void DotCreated(int lineId, Image dot)
        {
            var main = dot.transform.GetChild(0);
            var mainImage = main.GetComponent<Image>();
            mainImage.color = _colorPick[lineId].Color;
        }
    }
}