namespace IRM.WinForm.Utils.Messages;

public class DomainMessageSplit
{
    public string FieldName { get; private set; }
    public string Message { get; private set; }

    private DomainMessageSplit(string fieldName, string message)
    {
        FieldName = fieldName;
        Message = message;
    }

    public static DomainMessageSplit SplitMessage(string message)
    {
        if (!message.Contains('-'))
            message = message + "-";

        var splitMessage = message.Split('-');
        return new DomainMessageSplit(splitMessage[1].Trim(), splitMessage[0].Trim());
    }

}
