namespace App.Core.IO;
public class Node : IRunnable
{
    /* IRunnable Implementation */

    Thread? IRunnable.Thread { get; set; } = null;
	bool IRunnable.Shutdown { get; set; } = false;
	bool IRunnable.Startup { get; set; } = false;
	bool IRunnable.Running { get; set; } = false;
    void IRunnable.Tick() => Operate();


	/* Non-Implemented */
	protected virtual void Operate() => throw new NotImplementedException();
}