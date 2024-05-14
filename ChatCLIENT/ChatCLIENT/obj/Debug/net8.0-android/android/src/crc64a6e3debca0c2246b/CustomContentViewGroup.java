package crc64a6e3debca0c2246b;


public class CustomContentViewGroup
	extends crc6452ffdc5b34af3a0f.ContentViewGroup
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getAccessibilityClassName:()Ljava/lang/CharSequence;:GetGetAccessibilityClassNameHandler\n" +
			"n_onInitializeAccessibilityNodeInfo:(Landroid/view/accessibility/AccessibilityNodeInfo;)V:GetOnInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_Handler\n" +
			"";
		mono.android.Runtime.register ("IeuanWalker.Maui.Switch.Platform.CustomContentViewGroup, IeuanWalker.Maui.Switch", CustomContentViewGroup.class, __md_methods);
	}


	public CustomContentViewGroup (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomContentViewGroup.class) {
			mono.android.TypeManager.Activate ("IeuanWalker.Maui.Switch.Platform.CustomContentViewGroup, IeuanWalker.Maui.Switch", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public CustomContentViewGroup (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomContentViewGroup.class) {
			mono.android.TypeManager.Activate ("IeuanWalker.Maui.Switch.Platform.CustomContentViewGroup, IeuanWalker.Maui.Switch", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public CustomContentViewGroup (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomContentViewGroup.class) {
			mono.android.TypeManager.Activate ("IeuanWalker.Maui.Switch.Platform.CustomContentViewGroup, IeuanWalker.Maui.Switch", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public CustomContentViewGroup (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == CustomContentViewGroup.class) {
			mono.android.TypeManager.Activate ("IeuanWalker.Maui.Switch.Platform.CustomContentViewGroup, IeuanWalker.Maui.Switch", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3 });
		}
	}


	public java.lang.CharSequence getAccessibilityClassName ()
	{
		return n_getAccessibilityClassName ();
	}

	private native java.lang.CharSequence n_getAccessibilityClassName ();


	public void onInitializeAccessibilityNodeInfo (android.view.accessibility.AccessibilityNodeInfo p0)
	{
		n_onInitializeAccessibilityNodeInfo (p0);
	}

	private native void n_onInitializeAccessibilityNodeInfo (android.view.accessibility.AccessibilityNodeInfo p0);

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
