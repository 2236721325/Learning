namespace JWTLearn
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public int ExpirationHour { get; set; }//����ʱ�� �������1Сʱ
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}