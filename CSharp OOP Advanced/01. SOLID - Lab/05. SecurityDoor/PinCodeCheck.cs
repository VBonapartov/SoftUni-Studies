public class PinCodeCheck : SecurityCheck
{
    private IPinCodeUI pinCodeUI;

    public PinCodeCheck(IPinCodeUI pinCodeUI)
    {
        this.pinCodeUI = pinCodeUI;
    }

    public override bool ValidateUser()
    {
        int pin = this.pinCodeUI.RequestPinCode();
        if (this.IsValid(pin))
        {
            return true;
        }

        return false;
    }

    private bool IsValid(int pin)
    {
        return true;
    }
}