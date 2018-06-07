package md59d7b949c32d6bb58f02a4a7c674ff9cf;


public class AppSettings
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AdvertiserOverlay.Screens.AppSettings, AdvertiserOverlay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AppSettings.class, __md_methods);
	}


	public AppSettings () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AppSettings.class)
			mono.android.TypeManager.Activate ("AdvertiserOverlay.Screens.AppSettings, AdvertiserOverlay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
