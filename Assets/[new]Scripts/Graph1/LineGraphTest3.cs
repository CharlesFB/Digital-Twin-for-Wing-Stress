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
    public class LineGraphTest3 : MonoBehaviour
    {
        private float[] mocklist = {
                121.796f,121.456f,121.439f,121.242f,120.914f,120.920f,120.676f,120.449f,120.580f,120.544f,120.384f,120.366f,120.473f,120.389f,120.693f,120.854f,120.872f,121.111f,121.289f,121.582f,121.880f,122.178f,122.315f,122.583f,122.744f,122.857f,123.173f,123.215f,123.656f,123.924f,124.186f,124.502f,124.788f,124.973f,125.307f,125.712f,126.231f,126.380f,126.415f,126.565f,127.083f,127.262f,127.435f,127.441f,127.399f,127.316f,127.369f,127.000f,126.910f,126.821f,126.511f,126.243f,126.022f,125.927f,125.742f,125.510f,125.563f,125.587f,125.653f,125.629f,125.659f,125.664f,125.611f,125.474f,125.480f,125.635f,125.492f,125.498f,125.450f,125.545f,125.462f,125.152f,125.247f,124.949f,125.235f,125.426f,125.313f,125.468f,125.539f,125.706f,125.915f,126.165f,126.410f,126.791f,127.065f,127.524f,127.643f,127.840f,127.876f,128.078f,128.138f,127.900f,127.858f,127.536f,127.345f,127.161f,126.934f,126.868f,126.487f,126.201f,
                126.237f,126.004f,125.974f,125.706f,125.563f,125.670f,125.611f,125.676f,125.796f,125.623f,125.676f,125.331f,125.337f,125.527f,125.289f,125.253f,125.158f,125.301f,125.450f,125.414f,125.432f,125.498f,125.378f,125.378f,125.486f,125.587f,125.772f,125.986f,125.951f,126.028f,126.231f,126.177f,126.165f,126.165f,126.064f,125.945f,125.873f,125.998f,125.766f,125.462f,125.295f,124.925f,124.878f,124.431f,124.365f,123.906f,123.549f,123.394f,123.161f,122.714f,122.362f,122.136f,121.820f,121.421f,121.087f,120.836f,120.676f,120.550f,120.240f,120.187f,119.925f,119.770f,119.632f,119.746f,119.698f,119.752f,119.966f,120.056f,120.550f,120.836f,120.866f,121.069f,121.289f,121.331f,121.480f,121.683f,121.701f,121.862f,121.909f,122.142f,122.094f,122.112f,122.315f,122.178f,122.279f,122.386f,122.458f,122.583f,122.380f,122.243f,122.476f,122.476f,122.613f,122.648f,122.428f,122.577f,122.327f,122.523f,122.225f,122.082f,
                121.886f,121.564f,121.289f,121.129f,121.069f,120.860f,120.753f,120.485f,120.485f,120.604f,120.324f,120.479f,120.401f,120.473f,120.652f,120.705f,121.146f,121.170f,121.421f,121.737f,121.874f,121.963f,122.249f,122.476f,122.571f,122.911f,123.161f,123.477f,123.650f,123.906f,124.007f,124.329f,124.526f,124.848f,125.211f,125.444f,125.903f,126.410f,126.505f,126.523f,127.065f,127.327f,127.256f,127.476f,127.226f,127.333f,127.268f,127.137f,127.077f,126.922f,126.481f,126.410f,126.106f,126.004f,125.933f,125.837f,125.629f,125.724f,125.688f,125.712f,125.670f,125.563f,125.629f,125.670f,125.670f,125.682f,125.659f,125.587f,125.575f,125.468f,125.432f,125.438f,125.200f,125.122f,125.182f,125.140f,125.110f,125.396f,125.390f,125.664f,125.808f,126.058f,126.451f,126.570f,126.958f,127.298f,127.620f,127.733f,127.810f,128.114f,128.043f,127.971f,127.882f,127.673f,127.453f,127.304f,127.172f,126.880f,126.767f,126.553f,
                126.237f,126.177f,125.867f,125.742f,125.855f,125.521f,125.575f,125.736f,125.605f,125.659f,125.688f,125.617f,125.480f,125.492f,125.366f,125.259f,125.217f,125.223f,125.390f,125.372f,125.319f,125.355f,125.360f,125.349f,125.408f,125.545f,125.581f,125.861f,125.855f,125.873f,126.106f,126.290f,126.219f,126.219f,126.088f,125.903f,125.909f,125.909f,125.790f,125.641f,125.510f,125.033f,124.830f,124.568f,124.323f,124.103f,123.656f,123.537f,123.084f,122.881f,122.482f,122.261f,121.832f,121.409f,121.230f,120.795f,120.801f,120.491f,120.425f,120.211f,120.080f,119.853f,119.793f,119.883f,119.781f,119.656f,119.901f,120.211f,120.181f,120.467f,120.717f,120.854f,121.051f,121.164f,121.522f,121.623f,121.629f,121.903f,121.880f,121.957f,122.076f,121.999f,122.184f,122.195f,122.172f,122.267f,122.464f,122.476f,122.613f,122.213f,122.482f,122.654f,122.523f,122.541f,122.601f,122.654f,122.398f,122.350f,122.333f,122.052f,
                121.981f,121.677f,121.456f,121.212f,121.069f,121.099f,120.789f,120.592f,120.455f,120.491f,120.479f,120.336f,120.342f,120.419f,120.509f,120.747f,120.932f,121.069f,121.349f,121.456f,121.659f,121.957f,122.190f,122.523f,122.577f,122.672f,123.030f,123.399f,123.435f,123.703f,123.960f,124.341f,124.604f,124.818f,125.098f,125.390f,125.790f,126.243f,126.588f,126.487f,126.886f,127.214f,127.268f,127.351f,127.411f,127.286f,127.232f,127.149f,127.184f,126.898f,126.725f,126.505f,126.159f,126.100f,125.909f,125.808f,125.694f,125.706f,125.575f,125.647f,125.581f,125.659f,125.676f,125.611f,125.694f,125.694f,125.557f,125.575f,125.545f,125.372f,125.366f,125.396f,125.211f,125.128f,125.277f,125.158f,125.140f,125.355f,125.533f,125.724f,125.784f,125.957f,126.076f,126.511f,126.845f,127.238f,127.429f,127.798f,127.804f,127.918f,128.043f,127.918f,127.947f,127.900f,127.482f,127.262f,127.119f,126.952f,126.737f,126.338f,
                126.255f,126.028f,125.968f,125.897f,125.813f,125.629f,125.581f,125.647f,125.748f,125.796f,125.659f,125.539f,125.510f,125.271f,125.366f,125.432f,125.206f,125.283f,125.277f,125.355f,125.307f,125.360f,125.438f,125.426f,125.462f,125.402f,125.635f,125.802f,125.903f,125.986f,126.004f,126.302f,126.153f,126.195f,126.106f,126.016f,126.058f,125.939f,125.790f,125.551f,125.557f,125.206f,124.842f,124.812f,124.407f,124.198f,123.847f,123.554f,123.191f,123.018f,122.684f,122.452f,121.987f,121.641f,121.301f,120.986f,120.836f,120.527f,120.401f,120.151f,119.996f,119.966f,119.680f,119.686f,119.776f,119.585f,119.865f,120.026f,120.181f,120.604f,120.676f,120.783f,121.158f,121.242f,121.450f,121.641f,121.677f,121.886f,121.790f,121.897f,122.178f,121.915f,122.279f,122.231f,122.166f,122.297f,122.237f,122.458f,122.553f,122.231f,122.273f,122.511f,122.464f,122.410f,122.589f,122.720f,122.499f,122.422f,122.237f,122.291f,
                122.088f,121.814f,121.623f,121.284f,121.200f,120.986f,120.950f,120.652f,120.628f,120.658f,120.467f,120.467f,120.485f,120.443f,120.568f,120.491f,120.807f,120.938f,121.194f,121.599f,121.564f,121.832f,122.160f,122.446f,122.577f,122.762f,122.964f,123.060f,123.382f,123.733f,123.858f,124.210f,124.574f,124.741f,124.961f,125.277f,125.760f,126.004f,126.487f,126.553f,126.463f,127.167f,127.351f,127.369f,127.321f,127.363f,127.202f,127.333f,127.155f,126.874f,126.612f,126.499f,126.314f,126.082f,125.843f,125.885f,125.682f,125.486f,125.659f,125.557f,125.581f,125.688f,125.510f,125.527f,125.533f,125.563f,125.504f,125.623f,125.575f,125.462f,125.390f,125.265f,125.128f,125.039f,125.146f,125.039f,125.104f,125.170f,125.498f,125.521f,125.587f,125.998f,126.052f,126.392f,126.797f,126.910f,127.262f,127.584f,127.912f,127.894f,127.840f,127.971f,127.977f,127.763f,127.524f,127.256f,127.298f,126.934f,126.785f,126.433f,
                126.261f,126.141f,125.998f,126.046f,125.766f,125.635f,125.659f,125.736f,125.623f,125.659f,125.617f,125.617f,125.396f,125.265f,125.217f,125.396f,125.307f,125.235f,125.343f,125.384f,125.301f,125.301f,125.259f,125.343f,125.486f,125.426f,125.718f,125.754f,125.927f,126.028f,125.927f,126.100f,126.076f,126.207f,126.094f,126.082f,125.897f,126.004f,125.831f,125.682f,125.468f,125.289f,125.122f,124.770f,124.401f,124.216f,123.829f,123.692f,123.340f,123.006f,122.887f,122.470f,122.100f,121.623f,121.313f,121.087f,120.890f,120.753f,120.461f,120.276f,119.984f,119.919f,119.704f,119.680f,119.728f,119.632f,119.770f,119.966f,120.264f,120.544f,120.699f,120.783f,120.884f,121.158f,121.319f,121.582f,121.683f,121.838f,121.939f,121.874f,122.088f,122.064f,122.118f,122.184f,122.279f,122.279f,122.327f,122.470f,122.625f,122.285f,122.088f,122.416f,122.523f,122.446f,122.553f,122.708f,122.356f,122.267f,122.291f,122.303f,
                122.052f,121.778f,121.719f,121.343f,121.140f,120.980f,120.968f,120.747f,120.670f,120.461f,120.389f,120.401f,120.199f,120.384f,120.521f,120.533f,120.693f,121.063f,121.218f,121.337f,121.433f,121.903f,122.017f,122.225f,122.321f,122.833f,122.952f,123.167f,123.328f,123.489f,124.085f,124.168f,124.401f,124.544f,124.967f,125.253f,125.563f,126.010f,126.481f,126.374f,126.517f,126.994f,127.190f,127.316f,127.387f,127.304f,127.268f,127.196f,127.202f,126.958f,126.857f,126.553f,126.165f,126.064f,125.885f,125.849f,125.766f,125.563f,125.796f,125.599f,125.647f,125.730f,125.492f,125.593f,125.480f,125.599f,125.611f,125.498f,125.563f,125.527f,125.480f,125.360f,125.283f,125.170f,125.051f,125.349f,125.045f,125.331f,125.414f,125.480f,125.748f,125.736f,126.112f,126.356f,126.684f,127.077f,127.333f,127.560f,128.007f,127.804f,127.923f,128.144f,127.935f,127.745f,127.578f,127.405f,127.161f,126.958f,126.880f,126.630f
            };
        private int imock = 0;

        [Header("TimerPick")]
        public float pickTime = 0.005f;
        public float runTime = 0.0016f;
        [Range(1,30)]
        public int skip = 30;
        private Queue<float> ql;
        private Queue<float> mockPrediction;
        public SocketController sc;

        private float timer1 = 0.0016f;
        private float timer2 = 0.005f;

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
            int sourceLength = source.Length;

            for (int i = 0; i < length; i++)
            {
                // 通过取模运算实现数组下标循环
                int currentIndex = (startIndex + i) % sourceLength;
                result[i] = source[currentIndex];
            }

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

        [SerializeField] private LineGraph3 lineGraph;
        [SerializeField] private MockLine[] data;
        [SerializeField] private FunctionLine[] funcData;
        [SerializeField] private Type type;
        [SerializeField] private TMP_Dropdown dropdown;
        [SerializeField] private Image lineHighlightPrefab;
        [SerializeField] private bool changeDiscritization;
        private IList<IColorPick> _colorPick;

        private void Awake()
        {
            funcData[0].xValues = new List<float>();
            funcData[1].xValues = new List<float>();
            for (int i = 0; i < 15; i++)
            {
                funcData[0].xValues.Add(i);
            }
            ql = new Queue<float>();
            mockPrediction = new Queue<float>();
            for (int i = 0; i < 16; i++)
            {
                funcData[1].xValues.Add(i);
                ql.Enqueue(0);
                mockPrediction.Enqueue(0);
            }
        }

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

        public static float GenerateNormalRandom(float mean = 0f, float stdDev = 1f, float min = -30f, float max = 30f)
        {
            float u1 = UnityEngine.Random.value; // 随机数 [0,1]
            float u2 = UnityEngine.Random.value; // 随机数 [0,1]

            // Box-Muller 变换生成正态分布随机数
            float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);

            // 缩放到指定的均值和标准差
            float randNormal = mean + stdDev * randStdNormal;

            // 限制范围在 (-5, 5)
            randNormal = Mathf.Clamp(randNormal, min, max);

            return randNormal;
        }

        private void Update()
        {
            lineGraph.Clear();
            Plot();
        }

        public float mock_offset = 0f;

        public void EnqueueQL(float x)
        {
            if (ql.Count != 0)
            {
                ql.Dequeue();
                mockPrediction.Dequeue();
            }
            ql.Enqueue(x);
            mockPrediction.Enqueue(x + GenerateNormalRandom(0, 3) + mock_offset);
        }

        private void SetType(int arg0)
        {
            var setType = (Type)arg0;
            type = setType;
            lineGraph.Clear();
            Plot();
        }

        private float GenerateFromQueue(float x, int i)
        {
            switch (i)
            {
                case 0:
                    int dx = (int)Mathf.Floor(x);
                    if (ql == null || ql.Count == 0) return 0;
                    if (dx < 0 || dx >= 15) return 0;

                    int iq = 0;

                    foreach (float q in ql)
                    {
                        if (iq == dx)
                            return q;
                        iq += 1;
                    }
                    break;
                case 1:
                    int dx1 = (int)Mathf.Floor(x);
                    if (mockPrediction == null || mockPrediction.Count == 0) return 0;
                    if (dx1 < 0 || dx1 >= 16) return 0;

                    int iq1 = 0;

                    foreach (float q in mockPrediction)
                    {
                        if (iq1 == dx1)
                            return q;
                        iq1 += 1;
                    }
                    break;
            }
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
                            Func<float, float> function = (x) => GenerateFromQueue(x, i);
                                    
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