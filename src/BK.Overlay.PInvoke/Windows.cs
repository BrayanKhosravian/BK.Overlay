using System;
using System.Runtime.InteropServices;

namespace BK.Overlay.PInvoke
{
	public static class Windows
	{
		// The GetWindowRect function takes a handle to the window as the first parameter. The second parameter
		// must include a reference to a Rectangle object. This Rectangle object will then have it's values set
		// to the window rectangle properties.
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowRect(HandleRef hWnd, out Rect lpRect);

		// https://www.pinvoke.net/default.aspx/user32.SetWindowLong
		[DllImport("user32.dll", EntryPoint = "GetWindowLong")]
		public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

		// This helper static method is required because the 32-bit version of user32.dll does not contain this API
		// (on any versions of Windows), so linking the method will fail at run-time. The bridge dispatches the request
		// to the correct function (GetWindowLong in 32-bit mode and GetWindowLongPtr in 64-bit mode)
		public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, int dwNewLong)
		{
			if (IntPtr.Size == 8)
				return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
			else
				return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong));
		}

		[DllImport("user32.dll", EntryPoint = "SetWindowLong")]
		private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
		private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, int dwNewLong);


		public enum Classes
		{
			GCL_STYLE = -26,     // Retrieves the window-class style bits.
		}

		public enum ClassStyles
		{
			CS_DBLCLKS = 0x0008,  // Sends a double-click message to the window procedure when the user double-clicks the mouse while the cursor is within a window belonging to the class.
		}

		public static IntPtr GetClassLongPtr(HandleRef hWnd, int nIndex)
		{
			if (IntPtr.Size > 4)
				return GetClassLongPtr64(hWnd, nIndex);
			else
				return new IntPtr(GetClassLongPtr32(hWnd, nIndex));
		}

		[DllImport("user32.dll", EntryPoint = "GetClassLong")]
		private static extern uint GetClassLongPtr32(HandleRef hWnd, int nIndex);

		[DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
		private static extern IntPtr GetClassLongPtr64(HandleRef hWnd, int nIndex);

		public static IntPtr SetClassLong(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
		{
			if (IntPtr.Size > 4)
				return SetClassLongPtr64(hWnd, nIndex, dwNewLong);
			else
				return new IntPtr(SetClassLongPtr32(hWnd, nIndex, unchecked((uint)dwNewLong.ToInt32())));
		}

		[DllImport("user32.dll", EntryPoint = "SetClassLong")]
		private static extern uint SetClassLongPtr32(HandleRef hWnd, int nIndex, uint dwNewLong);

		[DllImport("user32.dll", EntryPoint = "SetClassLongPtr")]
		private static extern IntPtr SetClassLongPtr64(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.U2)]
		public static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);

	}
}
