package md5f2ed4ada4ff509108f4357be92dfe0fb;


public class Messages
	extends md57d3c464eb1bc0fb5668a0a0ba55a81c4.base
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("EGamDroid.Screens.Messages, EGamDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Messages.class, __md_methods);
	}


	public Messages () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Messages.class)
			mono.android.TypeManager.Activate ("EGamDroid.Screens.Messages, EGamDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
