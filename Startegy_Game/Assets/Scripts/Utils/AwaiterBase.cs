using System;

namespace Utils
{
    public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
    {
        protected Action _continuation;
        protected bool _isCompleted;
        protected TAwaited _result;

        public bool IsCompleted => _isCompleted;

        public TAwaited GetResult() => _result;
        
        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }

        protected void ONWaitFinish(TAwaited result)
        {
            _result = result;
            _isCompleted = true;
            _continuation?.Invoke();
        }
    }
}