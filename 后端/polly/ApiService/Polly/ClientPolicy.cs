using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Timeout;

namespace ApiService.Polly
{
    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry { get; }
        public AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry { get; }
        public AsyncRetryPolicy<HttpResponseMessage> ExponentialHttpRetry { get; }
        public AsyncCircuitBreakerPolicy<HttpResponseMessage> TestCircuitBreaker { get; }

        public TimeoutPolicy<HttpMessageHandler> TestTimeOut { get; }
        public ClientPolicy()
        {
            ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(res =>!res.IsSuccessStatusCode)
                .RetryAsync(5);//立即重试     

            LinearHttpRetry = Policy.HandleResult<HttpResponseMessage>(res=>!res.IsSuccessStatusCode)
                .WaitAndRetryAsync(5,retryAttempt=>TimeSpan.FromSeconds(3));//等待固定时间

            ExponentialHttpRetry = Policy.HandleResult<HttpResponseMessage>(res=>!res.IsSuccessStatusCode).
                WaitAndRetryAsync(5,retryAttempt=>TimeSpan.FromSeconds(Math.Pow(2,retryAttempt))); //等待指数增长时间
                                                                                                   //
            TestCircuitBreaker = Policy.HandleResult<HttpResponseMessage>(res=>!res.IsSuccessStatusCode).             
                CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));
            //TestTimeOut = Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode)
            //     .Execute(() => { return new HttpResponseMessage(); });
            //TestTimeOut = Policy.HandleResult<HttpResponseMessage>(30).Execute(() => { return new HttpResponseMessage(); });
           

        }
        
    }

}