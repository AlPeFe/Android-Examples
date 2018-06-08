package md5823c408df52dce1461642ca1a1a78db1;


public class MessageActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("GamDroidUpgrade.Screens.MessageActivity, GamDroidUpgrade, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MessageActivity.class, __md_methods);
	}


	public MessageActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MessageActivity.class)
			mono.android.TypeManager.Activate ("GamDroidUpgrade.Screens.MessageActivity, GamDroidUpgrade, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
