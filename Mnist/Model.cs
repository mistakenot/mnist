namespace Mnist
{
    public class Model
    {
        private readonly Tensor _biases;
        private readonly Tensor _inputs;
        private readonly Tensor _labels;
        private readonly Tensor _weights;

        public Model(Tensor inputs, Tensor labels)
        {
            _inputs = inputs;
            _labels = labels;

            _weights = new Tensor(inputs.M, labels.N);
            _biases = new Tensor(labels.N, 1);
        }

        public Tensor Predict(Tensor inputs)
        {
            // y = softmax(Wx + b)
            var wx = _weights.DotProduct(inputs);
            var wx_b = wx.Add(_biases);
            var y = wx_b.Softmax();

            return y;
        }

        public void Train(int iterations)
        {
            
        }
    }
}