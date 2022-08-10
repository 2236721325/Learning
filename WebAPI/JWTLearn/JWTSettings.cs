namespace JWTLearn
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public int ExpirationHour { get; set; }//过期时间 这里就是1小时
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}