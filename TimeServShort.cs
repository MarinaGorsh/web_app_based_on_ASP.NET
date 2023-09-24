class ShortTimeService : ITimeService
{
    public string GetTime() {
        var nowTime = DateTime.Now.Hour;
        if (nowTime >= 6 && nowTime < 12)
        {
            return "Zaraz ranok";
        }
        else if (nowTime >= 12 && nowTime < 18)
        {
            return "Zaraz den";
        }
        else if (nowTime >= 18 && nowTime < 24)
        {
            return "Zaraz vechir";
        }
        else
        {
            return "Zaraz nich";
        }
    } 
}
