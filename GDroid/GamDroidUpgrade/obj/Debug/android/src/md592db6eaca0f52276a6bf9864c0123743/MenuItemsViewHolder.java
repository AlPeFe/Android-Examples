package md592db6eaca0f52276a6bf9864c0123743;


public class MenuItemsViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("GamDroidUpgrade.ViewHolders.MenuItemsViewHolder, GamDroidUpgrade, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MenuItemsViewHolder.class, __md_methods);
	}


	public MenuItemsViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == MenuItemsViewHolder.class)
			mono.android.TypeManager.Activate ("GamDroidUpgrade.ViewHolders.MenuItemsViewHolder, GamDroidUpgrade, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
