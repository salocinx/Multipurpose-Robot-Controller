namespace SendAndReceiveArguments
{
    class Program
    {
        static void Main()
        {
            // mimics Arduino calling structure
            var sendAndReceiveArguments = new SendAndReceiveArguments { RunLoop = true };
            sendAndReceiveArguments.Setup();
            sendAndReceiveArguments.Loop();
            sendAndReceiveArguments.Exit();
        }

    }
}
