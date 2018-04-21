public class KeyCardCheck : SecurityCheck
{
    private IKeyCardUI keyCardUI;

    public KeyCardCheck(IKeyCardUI keyCardUI)
    {
        this.keyCardUI = keyCardUI;
    }

    public override bool ValidateUser()
    {
        string code = this.keyCardUI.RequestKeyCard();
        if (this.IsValid(code))
        {
            return true;
        }

        return false;
    }

    private bool IsValid(string code)
    {
        return true;
    }
}