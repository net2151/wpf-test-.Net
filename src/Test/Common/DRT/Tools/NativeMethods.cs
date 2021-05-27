// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

//***************************************************************************
// HOW TO USE THIS FILE
//
// If you need access to a Win32 API that is not exposed, simply uncomment
// it in one of the following files:
// 
// NativeMethods.cs
// UnsafeNativeMethods.cs
// SafeNativeMethods.cs
//
// Only uncomment what you need to avoid code bloat.
//
// DO NOT adjust the visibility of anything in these files.  They are marked
// internal on pupose.
//***************************************************************************


namespace MS.Utility
{
    using Accessibility;
    using System.Runtime.InteropServices;
    using System;
    using System.Security.Permissions;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    
    public class NativeMethods
    {

        public static IntPtr InvalidIntPtr = ((IntPtr)((int)(-1)));
        public static HandleRef NullHandleRef = new HandleRef(null, IntPtr.Zero);

/*        
        public const int BITMAPINFO_MAX_COLORSIZE = 256;
        public const int BI_BITFIELDS = 3;

        public const int ARW_BOTTOMLEFT = 0x0000,
        ARW_BOTTOMRIGHT = 0x0001,
        ARW_TOPLEFT = 0x0002,
        ARW_TOPRIGHT = 0x0003,
        ARW_LEFT = 0x0000,
        ARW_RIGHT = 0x0000,
        ARW_UP = 0x0004,
        ARW_DOWN = 0x0004,
        ARW_HIDE = 0x0008,
        ACM_OPENA = (0x0400+100),
        ACM_OPENW = (0x0400+103),
        ADVF_ONLYONCE = 2,
        ADVF_PRIMEFIRST = 4;

        public const int BI_RGB = 0,
        BS_PATTERN = 3,
        BITSPIXEL = 12,
        BDR_RAISEDOUTER = 0x0001,
        BDR_SUNKENOUTER = 0x0002,
        BDR_RAISEDINNER = 0x0004,
        BDR_SUNKENINNER = 0x0008,
        BDR_RAISED = 0x0005,
        BDR_SUNKEN = 0x000a,
        BF_LEFT = 0x0001,
        BF_TOP = 0x0002,
        BF_RIGHT = 0x0004,
        BF_BOTTOM = 0x0008,
        BF_ADJUST = 0x2000,
        BF_FLAT = 0x4000,
        BF_MIDDLE = 0x0800,
        BFFM_INITIALIZED = 1,
        BFFM_SELCHANGED = 2,
        BFFM_SETSELECTION = 0x400+103,
        BFFM_ENABLEOK = 0x400+101,
        BS_PUSHBUTTON = 0x00000000,
        BS_DEFPUSHBUTTON = 0x00000001,
        BS_MULTILINE = 0x00002000,
        BS_PUSHLIKE = 0x00001000,
        BS_OWNERDRAW = 0x0000000B,
        BS_RADIOBUTTON = 0x00000004,
        BS_3STATE = 0x00000005,
        BS_GROUPBOX = 0x00000007,
        BS_LEFT = 0x00000100,
        BS_RIGHT = 0x00000200,
        BS_CENTER = 0x00000300,
        BS_TOP = 0x00000400,
        BS_BOTTOM = 0x00000800,
        BS_VCENTER = 0x00000C00,
        BS_RIGHTBUTTON = 0x00000020,
        BN_CLICKED = 0,
        BM_SETCHECK = 0x00F1,
        BM_SETSTATE = 0x00F3;

        public const int CDERR_DIALOGFAILURE = 0xFFFF,
        CDERR_STRUCTSIZE = 0x0001,
        CDERR_INITIALIZATION = 0x0002,
        CDERR_NOTEMPLATE = 0x0003,
        CDERR_NOHINSTANCE = 0x0004,
        CDERR_LOADSTRFAILURE = 0x0005,
        CDERR_FINDRESFAILURE = 0x0006,
        CDERR_LOADRESFAILURE = 0x0007,
        CDERR_LOCKRESFAILURE = 0x0008,
        CDERR_MEMALLOCFAILURE = 0x0009,
        CDERR_MEMLOCKFAILURE = 0x000A,
        CDERR_NOHOOK = 0x000B,
        CDERR_REGISTERMSGFAIL = 0x000C,
        CFERR_NOFONTS = 0x2001,
        CFERR_MAXLESSTHANMIN = 0x2002,
        CC_RGBINIT = 0x00000001,
        CC_FULLOPEN = 0x00000002,
        CC_PREVENTFULLOPEN = 0x00000004,
        CC_SHOWHELP = 0x00000008,
        CC_ENABLEHOOK = 0x00000010,
        CC_SOLIDCOLOR = 0x00000080,
        CC_ANYCOLOR = 0x00000100,
        CF_SCREENFONTS = 0x00000001,
        CF_SHOWHELP = 0x00000004,
        CF_ENABLEHOOK = 0x00000008,
        CF_INITTOLOGFONTSTRUCT = 0x00000040,
        CF_EFFECTS = 0x00000100,
        CF_APPLY = 0x00000200,
        CF_SCRIPTSONLY = 0x00000400,
        CF_NOVECTORFONTS = 0x00000800,
        CF_NOSIMULATIONS = 0x00001000,
        CF_LIMITSIZE = 0x00002000,
        CF_FIXEDPITCHONLY = 0x00004000,
        CF_FORCEFONTEXIST = 0x00010000,
        CF_TTONLY = 0x00040000,
        CF_SELECTSCRIPT = 0x00400000,
        CF_NOVERTFONTS = 0x01000000,
        CP_WINANSI = 1004;
        
        public const int cmb4 = 0x0473,
        CS_DBLCLKS = 0x0008,
        CF_TEXT = 1,
        CF_BITMAP = 2,
        CF_METAFILEPICT = 3,
        CF_SYLK = 4,
        CF_DIF = 5,
        CF_TIFF = 6,
        CF_OEMTEXT = 7,
        CF_DIB = 8,
        CF_PALETTE = 9,
        CF_PENDATA = 10,
        CF_RIFF = 11,
        CF_WAVE = 12,
        CF_UNICODETEXT = 13,
        CF_ENHMETAFILE = 14,
        CF_HDROP = 15,
        CF_LOCALE = 16,
        CW_USEDEFAULT = (unchecked((int)0x80000000)),
        CWP_SKIPINVISIBLE = 0x0001,
        COLOR_WINDOW = 5,
        CB_ERR = (-1),
        CBN_SELCHANGE = 1,
        CBN_DBLCLK = 2,
        CBN_EDITCHANGE = 5,
        CBN_DROPDOWN = 7,
        CBN_SELENDOK = 9,
        CBS_SIMPLE = 0x0001,
        CBS_DROPDOWN = 0x0002,
        CBS_DROPDOWNLIST = 0x0003,
        CBS_OWNERDRAWFIXED = 0x0010,
        CBS_OWNERDRAWVARIABLE = 0x0020,
        CBS_AUTOHSCROLL = 0x0040,
        CBS_HASSTRINGS = 0x0200,
        CBS_NOINTEGRALHEIGHT = 0x0400,
        CB_GETEDITSEL = 0x0140,
        CB_LIMITTEXT = 0x0141,
        CB_SETEDITSEL = 0x0142,
        CB_ADDSTRING = 0x0143,
        CB_DELETESTRING = 0x0144,
        CB_GETCURSEL = 0x0147,
        CB_INSERTSTRING = 0x014A,
        CB_RESETCONTENT = 0x014B,
        CB_FINDSTRING = 0x014C,
        CB_SETCURSEL = 0x014E,
        CB_SHOWDROPDOWN = 0x014F,
        CB_GETITEMDATA = 0x0150,
        CB_SETITEMHEIGHT = 0x0153,
        CB_GETITEMHEIGHT = 0x0154,
        CB_GETDROPPEDSTATE = 0x0157,
        CB_FINDSTRINGEXACT = 0x0158,
        CB_SETDROPPEDWIDTH = 0x0160,
        CDRF_DODEFAULT = 0x00000000,
        CDRF_NEWFONT = 0x00000002,
        CDRF_SKIPDEFAULT = 0x00000004,
        CDRF_NOTIFYPOSTPAINT = 0x00000010,
        CDRF_NOTIFYITEMDRAW = 0x00000020,
        CDRF_NOTIFYSUBITEMDRAW = CDRF_NOTIFYITEMDRAW,
        CDDS_PREPAINT = 0x00000001,
        CDDS_POSTPAINT = 0x00000002,
        CDDS_ITEM = 0x00010000,
        CDDS_SUBITEM = 0x00020000,
        CDDS_ITEMPREPAINT = (0x00010000|0x00000001),
        CDIS_SELECTED = 0x0001,
        CDIS_GRAYED = 0x0002,
        CDIS_DISABLED = 0x0004,
        CDIS_CHECKED = 0x0008,
        CDIS_FOCUS = 0x0010,
        CDIS_DEFAULT = 0x0020,
        CDIS_HOT = 0x0040,
        CDIS_MARKED = 0x0080,
        CDIS_INDETERMINATE = 0x0100,
        CLR_NONE = unchecked((int)0xFFFFFFFF),
        CLR_DEFAULT = unchecked((int)0xFF000000),
        CCS_NORESIZE = 0x00000004,
        CCS_NOPARENTALIGN = 0x00000008,
        CCS_NODIVIDER = 0x00000040,
        CBEM_INSERTITEMA = (0x0400+1),
        CBEM_GETITEMA = (0x0400+4),
        CBEM_SETITEMA = (0x0400+5),
        CBEM_INSERTITEMW = (0x0400+11),
        CBEM_SETITEMW = (0x0400+12),
        CBEM_GETITEMW = (0x0400+13),
        CBEN_ENDEDITA = ((0-800)-5),
        CBEN_ENDEDITW = ((0-800)-6),
        CONNECT_E_NOCONNECTION = unchecked((int)0x80040200),
        CONNECT_E_CANNOTCONNECT = unchecked((int)0x80040202),
        CTRLINFO_EATS_RETURN    = 1,
        CTRLINFO_EATS_ESCAPE    = 2,
        CSIDL_DESKTOP                    = 0x0000,        // <desktop>
        CSIDL_INTERNET                   = 0x0001,        // Internet Explorer (icon on desktop)
        CSIDL_PROGRAMS                   = 0x0002,        // Start Menu\Programs
        CSIDL_PERSONAL                   = 0x0005,        // My Documents
        CSIDL_FAVORITES                  = 0x0006,        // <user name>\Favorites
        CSIDL_STARTUP                    = 0x0007,        // Start Menu\Programs\Startup
        CSIDL_RECENT                     = 0x0008,        // <user name>\Recent
        CSIDL_SENDTO                     = 0x0009,        // <user name>\SendTo
        CSIDL_STARTMENU                  = 0x000b,        // <user name>\Start Menu
        CSIDL_DESKTOPDIRECTORY           = 0x0010,        // <user name>\Desktop
        CSIDL_TEMPLATES                  = 0x0015,
        CSIDL_APPDATA                    = 0x001a,        // <user name>\Application Data
        CSIDL_LOCAL_APPDATA              = 0x001c,        // <user name>\Local Settings\Applicaiton Data (non roaming)
        CSIDL_INTERNET_CACHE             = 0x0020,
        CSIDL_COOKIES                    = 0x0021,
        CSIDL_HISTORY                    = 0x0022,
        CSIDL_COMMON_APPDATA             = 0x0023,        // All Users\Application Data
        CSIDL_SYSTEM                     = 0x0025,        // GetSystemDirectory()
        CSIDL_PROGRAM_FILES              = 0x0026,        // C:\Program Files
        CSIDL_PROGRAM_FILES_COMMON       = 0x002b;        // C:\Program Files\Common

        public const int DUPLICATE = 0x06,
        DISPID_UNKNOWN = (-1),
        DISPID_PROPERTYPUT = (-3),
        DISPATCH_METHOD = 0x1,
        DISPATCH_PROPERTYGET = 0x2,
        DISPATCH_PROPERTYPUT = 0x4,
        DV_E_DVASPECT = unchecked((int)0x8004006B),
        DISP_E_MEMBERNOTFOUND = unchecked((int)0x80020003),
        DISP_E_PARAMNOTFOUND = unchecked((int)0x80020004),
        DISP_E_EXCEPTION = unchecked((int)0x80020009),
        DEFAULT_GUI_FONT = 17,
        DIB_RGB_COLORS = 0,
        DRAGDROP_E_NOTREGISTERED = unchecked((int)0x80040100),
        DRAGDROP_E_ALREADYREGISTERED = unchecked((int)0x80040101),
        DUPLICATE_SAME_ACCESS = 0x00000002,
        DFC_CAPTION = 1,
        DFC_MENU = 2,
        DFC_SCROLL = 3,
        DFC_BUTTON = 4,
        DFCS_CAPTIONCLOSE = 0x0000,
        DFCS_CAPTIONMIN = 0x0001,
        DFCS_CAPTIONMAX = 0x0002,
        DFCS_CAPTIONRESTORE = 0x0003,
        DFCS_CAPTIONHELP = 0x0004,
        DFCS_MENUARROW = 0x0000,
        DFCS_MENUCHECK = 0x0001,
        DFCS_MENUBULLET = 0x0002,
        DFCS_SCROLLUP = 0x0000,
        DFCS_SCROLLDOWN = 0x0001,
        DFCS_SCROLLLEFT = 0x0002,
        DFCS_SCROLLRIGHT = 0x0003,
        DFCS_SCROLLCOMBOBOX = 0x0005,
        DFCS_BUTTONCHECK = 0x0000,
        DFCS_BUTTONRADIO = 0x0004,
        DFCS_BUTTON3STATE = 0x0008,
        DFCS_BUTTONPUSH = 0x0010,
        DFCS_INACTIVE = 0x0100,
        DFCS_PUSHED = 0x0200,
        DFCS_CHECKED = 0x0400,
        DFCS_FLAT = 0x4000,
        DT_LEFT = 0x00000000,
        DT_RIGHT = 0x00000002,
        DT_VCENTER = 0x00000004,
        DT_SINGLELINE = 0x00000020,
        DT_NOCLIP = 0x00000100,
        DT_CALCRECT = 0x00000400,
        DT_NOPREFIX = 0x00000800,
        DT_EDITCONTROL = 0x00002000,
        DT_EXPANDTABS  = 0x00000040,
        DT_END_ELLIPSIS = 0x00008000,
        DT_RTLREADING = 0x00020000,
        DCX_WINDOW = 0x00000001,
        DCX_CACHE = 0x00000002,
        DCX_LOCKWINDOWUPDATE = 0x00000400,
        DI_NORMAL = 0x0003,
        DLGC_WANTARROWS = 0x0001,
        DLGC_WANTTAB = 0x0002,
        DLGC_WANTALLKEYS = 0x0004,
        DLGC_WANTCHARS = 0x0080,
        DTM_SETSYSTEMTIME = (0x1000+2),
        DTM_SETRANGE = (0x1000+4),
        DTM_SETFORMATA = (0x1000+5),
        DTM_SETFORMATW = (0x1000+50),
        DTM_SETMCCOLOR = (0x1000+6),
        DTM_SETMCFONT = (0x1000+9),
        DTS_UPDOWN = 0x0001,
        DTS_SHOWNONE = 0x0002,
        DTS_LONGDATEFORMAT = 0x0004,
        DTS_TIMEFORMAT = 0x0009,
        DTS_RIGHTALIGN = 0x0020,
        DTN_DATETIMECHANGE = ((0-760)+1),
        DTN_USERSTRINGA = ((0-760)+2),
        DTN_USERSTRINGW = ((0-760)+15),
        DTN_WMKEYDOWNA = ((0-760)+3),
        DTN_WMKEYDOWNW = ((0-760)+16),
        DTN_FORMATA = ((0-760)+4),
        DTN_FORMATW = ((0-760)+17),
        DTN_FORMATQUERYA = ((0-760)+5),
        DTN_FORMATQUERYW = ((0-760)+18),
        DTN_DROPDOWN = ((0-760)+6),
        DTN_CLOSEUP = ((0-760)+7),
        DVASPECT_CONTENT   = 1,
        DVASPECT_TRANSPARENT = 32,
        DVASPECT_OPAQUE    = 16;

        public const int E_NOTIMPL = unchecked((int)0x80004001),
        E_OUTOFMEMORY = unchecked((int)0x8007000E),
        E_INVALIDARG = unchecked((int)0x80070057),
        E_NOINTERFACE = unchecked((int)0x80004002),
        E_FAIL = unchecked((int)0x80004005),
        E_ABORT = unchecked((int)0x80004004),
        E_UNEXPECTED = unchecked((int)0x8000FFFF),
        ETO_OPAQUE = 0x0002,
        ETO_CLIPPED = 0x0004,
        EMR_POLYTEXTOUTA = 96,
        EMR_POLYTEXTOUTW = 97,
        EDGE_RAISED = (0x0001|0x0004),
        EDGE_SUNKEN = (0x0002|0x0008),
        EDGE_ETCHED = (0x0002|0x0004),
        EDGE_BUMP = (0x0001|0x0008),
        ES_LEFT = 0x0000,
        ES_CENTER = 0x0001,
        ES_RIGHT = 0x0002,
        ES_MULTILINE = 0x0004,
        ES_UPPERCASE = 0x0008,
        ES_LOWERCASE = 0x0010,
        ES_AUTOVSCROLL = 0x0040,
        ES_AUTOHSCROLL = 0x0080,
        ES_NOHIDESEL = 0x0100,
        ES_READONLY = 0x0800,
        EN_CHANGE = 0x0300,
        EN_HSCROLL = 0x0601,
        EN_VSCROLL = 0x0602,
        EN_ALIGN_LTR_EC = 0x0700,
        EN_ALIGN_RTL_EC = 0x0701,
        EC_LEFTMARGIN = 0x0001,
        EC_RIGHTMARGIN = 0x0002,
        EM_GETSEL = 0x00B0,
        EM_SETSEL = 0x00B1,
        EM_SCROLL = 0x00B5,
        EM_SCROLLCARET = 0x00B7,
        EM_GETMODIFY = 0x00B8,
        EM_SETMODIFY = 0x00B9,
        EM_GETLINECOUNT = 0x00BA,
        EM_REPLACESEL = 0x00C2,
        EM_GETLINE = 0x00C4,
        EM_LIMITTEXT = 0x00C5,
        EM_CANUNDO = 0x00C6,
        EM_UNDO = 0x00C7,
        EM_SETPASSWORDCHAR = 0x00CC,
        EM_EMPTYUNDOBUFFER = 0x00CD,
        EM_SETREADONLY = 0x00CF,
        EM_SETMARGINS = 0x00D3,
        EM_POSFROMCHAR = 0x00D6,
        EM_CHARFROMPOS = 0x00D7;

        public const int FNERR_SUBCLASSFAILURE = 0x3001,
        FNERR_INVALIDFILENAME = 0x3002,
        FNERR_BUFFERTOOSMALL = 0x3003,
        FRERR_BUFFERLENGTHZERO = 0x4001,
        FADF_BSTR = (0x100),
        FADF_UNKNOWN = (0x200),
        FADF_DISPATCH = (0x400),
        FADF_VARIANT = (unchecked((int)0x800)),
        FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000,
        FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200,
        FVIRTKEY = 0x01,
        FSHIFT = 0x04,
        FALT = 0x10;

        public const int GMEM_MOVEABLE = 0x0002,
        GMEM_ZEROINIT = 0x0040,
        GMEM_DDESHARE = 0x2000,
    
        GWL_WNDPROC = (-4),
        GWL_HWNDPARENT = (-8),
        GWL_STYLE = (-16),
        GWL_EXSTYLE = (-20),
        GWL_ID = (-12),
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_CHILD = 5,
        GMR_VISIBLE = 0,
        GMR_DAYSTATE = 1,
        GDI_ERROR = (unchecked((int)0xFFFFFFFF)),
        GDTR_MIN = 0x0001,
        GDTR_MAX = 0x0002,
        GDT_VALID = 0,
        GDT_NONE = 1;

        public const int HOLLOW_BRUSH = 5,
        HC_ACTION = 0,
        HC_GETNEXT = 1,
        HC_SKIP = 2,
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTBOTTOM = 15,
        HTBOTTOMRIGHT = 17,
        HELPINFO_WINDOW = 0x0001,
        HCF_HIGHCONTRASTON = 0x00000001,
        HDM_GETITEMCOUNT = (0x1200+0),
        HDM_INSERTITEMA = (0x1200+1),
        HDM_INSERTITEMW = (0x1200+10),
        HDM_GETITEMA = (0x1200+3),
        HDM_GETITEMW = (0x1200+11),
        HDM_SETITEMA = (0x1200+4),
        HDM_SETITEMW = (0x1200+12),
        HDN_ITEMCHANGINGA = ((0-300)-0),
        HDN_ITEMCHANGINGW = ((0-300)-20),
        HDN_ITEMCHANGEDA = ((0-300)-1),
        HDN_ITEMCHANGEDW = ((0-300)-21),
        HDN_ITEMCLICKA = ((0-300)-2),
        HDN_ITEMCLICKW = ((0-300)-22),
        HDN_ITEMDBLCLICKA = ((0-300)-3),
        HDN_ITEMDBLCLICKW = ((0-300)-23),
        HDN_DIVIDERDBLCLICKA = ((0-300)-5),
        HDN_DIVIDERDBLCLICKW = ((0-300)-25),
        HDN_BEGINTRACKA = ((0-300)-6),
        HDN_BEGINTRACKW = ((0-300)-26),
        HDN_ENDTRACKA = ((0-300)-7),
        HDN_ENDTRACKW = ((0-300)-27),
        HDN_TRACKA = ((0-300)-8),
        HDN_TRACKW = ((0-300)-28),
        HDN_GETDISPINFOA = ((0-300)-9),
        HDN_GETDISPINFOW = ((0-300)-29);

        public static HandleRef HWND_TOP = new HandleRef(null, (IntPtr)0);
        public static HandleRef HWND_BOTTOM = new HandleRef(null, (IntPtr)1);
        public static HandleRef HWND_TOPMOST = new HandleRef(null, new IntPtr(-1));
        public static HandleRef HWND_NOTOPMOST = new HandleRef(null, new IntPtr(-2));
        public static HandleRef HWND_MESSAGE = new HandleRef( null, new IntPtr( -3 ));

        public const int IME_CMODE_NATIVE = 0x0001,
        IME_CMODE_KATAKANA = 0x0002,
        IME_CMODE_FULLSHAPE = 0x0008,
        INPLACE_E_NOTOOLSPACE = unchecked((int)0x800401A1),
        ICON_SMALL = 0,
        ICON_BIG = 1,
        IDC_ARROW = 32512,
        IDC_IBEAM = 32513,
        IDC_WAIT = 32514,
        IDC_CROSS = 32515,
        IDC_SIZEALL = 32646,
        IDC_SIZENWSE = 32642,
        IDC_SIZENESW = 32643,
        IDC_SIZEWE = 32644,
        IDC_SIZENS = 32645,
        IDC_UPARROW = 32516,
        IDC_NO = 32648,
        IDC_APPSTARTING = 32650,
        IDC_HELP = 32651,
        IMAGE_ICON = 1,
        IMAGE_CURSOR = 2,
        ICC_LISTVIEW_CLASSES = 0x00000001,
        ICC_TREEVIEW_CLASSES = 0x00000002,
        ICC_BAR_CLASSES = 0x00000004,
        ICC_TAB_CLASSES = 0x00000008,
        ICC_PROGRESS_CLASS = 0x00000020,
        ICC_DATE_CLASSES = 0x00000100,
        ILC_MASK = 0x0001,
        ILC_COLOR = 0x0000,
        ILC_COLOR4 = 0x0004,
        ILC_COLOR8 = 0x0008,
        ILC_COLOR16 = 0x0010,
        ILC_COLOR24 = 0x0018,
        ILC_COLOR32 = 0x0020,
        ILD_NORMAL = 0x0000,
        ILD_TRANSPARENT = 0x0001,
        ILD_MASK = 0x0010,
        ILD_ROP = 0x0040;
        
        public const int KEYEVENTF_KEYUP = 0x0002;

        public const int LOGPIXELSX = 88,
        LOGPIXELSY = 90,
        LB_ERR = (-1),
        LB_ERRSPACE = (-2),
        LBN_SELCHANGE = 1,
        LBN_DBLCLK = 2,
        LB_ADDSTRING = 0x0180,
        LB_INSERTSTRING = 0x0181,
        LB_DELETESTRING = 0x0182,
        LB_RESETCONTENT = 0x0184,
        LB_SETSEL = 0x0185,
        LB_SETCURSEL = 0x0186,
        LB_GETSEL = 0x0187,
        LB_GETCARETINDEX = 0x019F,
        LB_GETCURSEL = 0x0188,
        LB_GETTEXT = 0x0189,
        LB_GETTEXTLEN = 0x018A,
        LB_GETTOPINDEX = 0x018E,
        LB_FINDSTRING = 0x018F,
        LB_GETSELCOUNT = 0x0190,
        LB_GETSELITEMS = 0x0191,
        LB_SETHORIZONTALEXTENT = 0x0194,
        LB_SETCOLUMNWIDTH = 0x0195,
        LB_SETTOPINDEX = 0x0197,
        LB_GETITEMRECT = 0x0198,
        LB_SETITEMHEIGHT = 0x01A0,
        LB_GETITEMHEIGHT = 0x01A1,
        LB_FINDSTRINGEXACT = 0x01A2,
        LB_ITEMFROMPOINT = 0x01A9,
        LB_SETLOCALE = 0x01A5;
        
        public const int LBS_NOTIFY = 0x0001,
        LBS_MULTIPLESEL = 0x0008,
        LBS_OWNERDRAWFIXED = 0x0010,
        LBS_OWNERDRAWVARIABLE = 0x0020,
        LBS_HASSTRINGS = 0x0040,
        LBS_USETABSTOPS = 0x0080,
        LBS_NOINTEGRALHEIGHT = 0x0100,
        LBS_MULTICOLUMN = 0x0200,
        LBS_WANTKEYBOARDINPUT = 0x0400,
        LBS_EXTENDEDSEL = 0x0800,
        LBS_DISABLENOSCROLL = 0x1000,
        LBS_NOSEL = 0x4000,
        LOCK_WRITE = 0x1,
        LOCK_EXCLUSIVE = 0x2,
        LOCK_ONLYONCE = 0x4,
        LVS_ICON = 0x0000,
        LVS_REPORT = 0x0001,
        LVS_SMALLICON = 0x0002,
        LVS_LIST = 0x0003,
        LVS_SINGLESEL = 0x0004,
        LVS_SHOWSELALWAYS = 0x0008,
        LVS_SORTASCENDING = 0x0010,
        LVS_SORTDESCENDING = 0x0020,
        LVS_SHAREIMAGELISTS = 0x0040,
        LVS_NOLABELWRAP = 0x0080,
        LVS_AUTOARRANGE = 0x0100,
        LVS_EDITLABELS = 0x0200,
        LVS_NOSCROLL = 0x2000,
        LVS_ALIGNTOP = 0x0000,
        LVS_ALIGNLEFT = 0x0800,
        LVS_NOCOLUMNHEADER = 0x4000,
        LVS_NOSORTHEADER = unchecked((int)0x8000),
        LVM_SETBKCOLOR = (0x1000+1),
        LVSIL_NORMAL = 0,
        LVSIL_SMALL = 1,
        LVSIL_STATE = 2,
        LVM_SETIMAGELIST = (0x1000+3),
        LVIF_TEXT = 0x0001,
        LVIF_IMAGE = 0x0002,
        LVIF_PARAM = 0x0004,
        LVIF_STATE = 0x0008,
        LVIS_FOCUSED = 0x0001,
        LVIS_SELECTED = 0x0002,
        LVIS_CUT = 0x0004,
        LVIS_DROPHILITED = 0x0008,
        LVIS_OVERLAYMASK = 0x0F00,
        LVIS_STATEIMAGEMASK = 0xF000,
        LVM_GETITEMA = (0x1000+5),
        LVM_GETITEMW = (0x1000+75),
        LVM_SETITEMA = (0x1000+6),
        LVM_SETITEMW = (0x1000+76),
        LVM_INSERTITEMA = (0x1000+7),
        LVM_INSERTITEMW = (0x1000+77),
        LVM_DELETEITEM = (0x1000+8),
        LVM_DELETECOLUMN = (0x1000+28),
        LVM_DELETEALLITEMS = (0x1000+9),
        LVNI_FOCUSED = 0x0001,
        LVNI_SELECTED = 0x0002,
        LVM_GETNEXTITEM = (0x1000+12),
        LVFI_PARAM = 0x0001,
        LVM_FINDITEMA = (0x1000+13),
        LVM_FINDITEMW = (0x1000+83),
        LVIR_BOUNDS = 0,
        LVIR_ICON = 1,
        LVIR_LABEL = 2,
        LVIR_SELECTBOUNDS = 3,
        LVM_GETITEMRECT = (0x1000+14),
        LVM_GETSTRINGWIDTHA = (0x1000+17),
        LVM_GETSTRINGWIDTHW = (0x1000+87),
        LVHT_ONITEM = (0x0002|0x0004|0x0008),
        LVHT_ONITEMSTATEICON = 0x0008,
        LVM_HITTEST = (0x1000+18),
        LVM_ENSUREVISIBLE = (0x1000+19),
        LVA_DEFAULT = 0x0000,
        LVA_ALIGNLEFT = 0x0001,
        LVA_ALIGNTOP = 0x0002,
        LVA_SNAPTOGRID = 0x0005,
        LVM_ARRANGE = (0x1000+22),
        LVM_EDITLABELA = (0x1000+23),
        LVM_EDITLABELW = (0x1000+118),
        LVCF_FMT = 0x0001,
        LVCF_WIDTH = 0x0002,
        LVCF_TEXT = 0x0004,
        LVCF_IMAGE = 0x0010,
        LVCF_ORDER = 0x0020,
        LVM_GETCOLUMNA = (0x1000+25),
        LVM_GETCOLUMNW = (0x1000+95),
        LVM_SETCOLUMNA = (0x1000+26),
        LVM_SETCOLUMNW = (0x1000+96),
        LVM_INSERTCOLUMNA = (0x1000+27),
        LVM_INSERTCOLUMNW = (0x1000+97),
        LVM_GETCOLUMNWIDTH = (0x1000+29),
        LVM_SETCOLUMNWIDTH = (0x1000+30),
        LVM_GETHEADER = (0x1000+31),
        LVM_SETTEXTCOLOR = (0x1000+36),
        LVM_SETTEXTBKCOLOR = (0x1000+38),
        LVM_GETTOPINDEX = (0x1000+39),
        LVM_SETITEMSTATE = (0x1000+43),
        LVM_GETITEMSTATE = (0x1000+44),
        LVM_GETITEMTEXTA = (0x1000+45),
        LVM_GETITEMTEXTW = (0x1000+115),
        LVM_GETHOTITEM = (0x1000+61),
        LVM_SETITEMTEXTA = (0x1000+46),
        LVM_SETITEMTEXTW = (0x1000+116),
        LVM_SETITEMCOUNT = (0x1000+47),
        LVM_SORTITEMS = (0x1000+48),
        LVM_GETSELECTEDCOUNT = (0x1000+50),
        LVM_GETISEARCHSTRINGA = (0x1000+52),
        LVM_GETISEARCHSTRINGW = (0x1000+117),
        LVM_SETEXTENDEDLISTVIEWSTYLE = (0x1000+54),
        LVS_EX_GRIDLINES = 0x00000001,
        LVS_EX_CHECKBOXES = 0x00000004,
        LVS_EX_TRACKSELECT = 0x00000008,
        LVS_EX_HEADERDRAGDROP = 0x00000010,
        LVS_EX_FULLROWSELECT = 0x00000020,
        LVS_EX_ONECLICKACTIVATE = 0x00000040,
        LVS_EX_TWOCLICKACTIVATE = 0x00000080,
        LVN_ITEMCHANGING = ((0-100)-0),
        LVN_ITEMCHANGED = ((0-100)-1),
        LVN_BEGINLABELEDITA = ((0-100)-5),
        LVN_BEGINLABELEDITW = ((0-100)-75),
        LVN_ENDLABELEDITA = ((0-100)-6),
        LVN_ENDLABELEDITW = ((0-100)-76),
        LVN_COLUMNCLICK = ((0-100)-8),
        LVN_BEGINDRAG = ((0-100)-9),
        LVN_BEGINRDRAG = ((0-100)-11),
        LVN_ODFINDITEMA = ((0-100)-52),
        LVN_ODFINDITEMW = ((0-100)-79),
        LVN_ITEMACTIVATE = ((0-100)-14),
        LVN_GETDISPINFOA = ((0-100)-50),
        LVN_GETDISPINFOW = ((0-100)-77),
        LVN_SETDISPINFOA = ((0-100)-51),
        LVN_SETDISPINFOW = ((0-100)-78),
        LVN_KEYDOWN = ((0-100)-55),
        
        LWA_COLORKEY            = 0x00000001,
        LWA_ALPHA               = 0x00000002;

        public const int LANG_NEUTRAL = 0x00,
                         LOCALE_IFIRSTDAYOFWEEK = 0x0000100C;   // first day of week specifier

        public static readonly int LOCALE_USER_DEFAULT = MAKELCID(LANG_USER_DEFAULT);
        public static readonly int LANG_USER_DEFAULT   = MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT);

        public static int MAKELANGID(int primary, int sub) {
            return ((ushort)(((short)sub) << 10)) | (ushort) primary;
        }
        
        /// <devdoc>
        ///     Creates an LCID from a LangId
        /// </devdoc>
        public static int MAKELCID(int lgid) {
            return MAKELCID(lgid, SORT_DEFAULT);
        }

        /// <devdoc>
        ///     Creates an LCID from a LangId
        /// </devdoc>
        public static int MAKELCID(int lgid, int sort) {
            return ((0xFFFF & lgid) | (((0x000f) & sort) << 16));
        }

        public const int MEMBERID_NIL = (-1),
*/        
        public const int MAX_PATH = 260;
/*
        MM_TEXT = 1,
        MM_ANISOTROPIC = 8,
        MK_LBUTTON = 0x0001,
        MK_RBUTTON = 0x0002,
        MK_SHIFT = 0x0004,
        MK_CONTROL = 0x0008,
        MK_MBUTTON = 0x0010,
        MNC_EXECUTE = 2,
        MIIM_STATE = 0x00000001,
        MIIM_ID = 0x00000002,
        MIIM_SUBMENU = 0x00000004,
        MIIM_TYPE = 0x00000010,
        MIIM_DATA = 0x00000020,
        MB_OK = 0x00000000,
        MF_BYCOMMAND = 0x00000000,
        MF_BYPOSITION = 0x00000400,
        MF_ENABLED = 0x00000000,
        MF_GRAYED = 0x00000001,
        MF_POPUP = 0x00000010,
        MF_SYSMENU = 0x00002000,
        MFT_MENUBREAK = 0x00000040,
        MFT_SEPARATOR = 0x00000800,
        MFT_RIGHTORDER = 0x00002000,
        MFT_RIGHTJUSTIFY = 0x00004000,
        MDITILE_VERTICAL = 0x0000,
        MDITILE_HORIZONTAL = 0x0001,
        MCM_SETMAXSELCOUNT = (0x1000+4),
        MCM_SETSELRANGE = (0x1000+6),
        MCM_GETMONTHRANGE = (0x1000+7),
        MCM_GETMINREQRECT = (0x1000+9),
        MCM_SETCOLOR = (0x1000+10),
        MCM_SETTODAY = (0x1000+12),
        MCM_GETTODAY = (0x1000+13),
        MCM_HITTEST = (0x1000+14),
        MCM_SETFIRSTDAYOFWEEK = (0x1000+15),
        MCM_SETRANGE = (0x1000+18),
        MCM_SETMONTHDELTA = (0x1000+20),
        MCM_GETMAXTODAYWIDTH = (0x1000+21),
        MCHT_TITLE = 0x00010000,
        MCHT_CALENDAR = 0x00020000,
        MCHT_TODAYLINK = 0x00030000,
        MCHT_TITLEBK = (0x00010000),
        MCHT_TITLEMONTH = (0x00010000|0x0001),
        MCHT_TITLEYEAR = (0x00010000|0x0002),
        MCHT_TITLEBTNNEXT = (0x00010000|0x01000000|0x0003),
        MCHT_TITLEBTNPREV = (0x00010000|0x02000000|0x0003),
        MCHT_CALENDARBK = (0x00020000),
        MCHT_CALENDARDATE = (0x00020000|0x0001),
        MCHT_CALENDARDATENEXT = ((0x00020000|0x0001)|0x01000000),
        MCHT_CALENDARDATEPREV = ((0x00020000|0x0001)|0x02000000),
        MCHT_CALENDARDAY = (0x00020000|0x0002),
        MCHT_CALENDARWEEKNUM = (0x00020000|0x0003),
        MCSC_TEXT = 1,
        MCSC_TITLEBK = 2,
        MCSC_TITLETEXT = 3,
        MCSC_MONTHBK = 4,
        MCSC_TRAILINGTEXT = 5,
        MCN_SELCHANGE = ((0-750)+1),
        MCN_GETDAYSTATE = ((0-750)+3),
        MCN_SELECT = ((0-750)+4),
        MCS_DAYSTATE = 0x0001,
        MCS_MULTISELECT = 0x0002,
        MCS_WEEKNUMBERS = 0x0004,
        MCS_NOTODAYCIRCLE = 0x0008,
        MCS_NOTODAY = 0x0010;

        public const int NIM_ADD = 0x00000000,
        NIM_MODIFY = 0x00000001,
        NIM_DELETE = 0x00000002,
        NIF_MESSAGE = 0x00000001,
        NIF_ICON = 0x00000002,
        NIF_TIP = 0x00000004,
        NFR_ANSI = 1,
        NFR_UNICODE = 2,
        NM_CLICK = ((0-0)-2),
        NM_DBLCLK = ((0-0)-3),
        NM_RCLICK = ((0-0)-5),
        NM_RDBLCLK = ((0-0)-6),
        NM_CUSTOMDRAW = ((0-0)-12),
        NM_RELEASEDCAPTURE = ((0-0)-16);

        public const int OFN_READONLY = 0x00000001,
        OFN_OVERWRITEPROMPT = 0x00000002,
        OFN_HIDEREADONLY = 0x00000004,
        OFN_NOCHANGEDIR = 0x00000008,
        OFN_SHOWHELP = 0x00000010,
        OFN_ENABLEHOOK = 0x00000020,
        OFN_NOVALIDATE = 0x00000100,
        OFN_ALLOWMULTISELECT = 0x00000200,
        OFN_PATHMUSTEXIST = 0x00000800,
        OFN_FILEMUSTEXIST = 0x00001000,
        OFN_CREATEPROMPT = 0x00002000,
        OFN_EXPLORER = 0x00080000,
        OFN_NODEREFERENCELINKS = 0x00100000,
        OFN_ENABLESIZING = 0x00800000,
        OFN_USESHELLITEM = 0x01000000,
        OLEIVERB_PRIMARY = 0,
        OLEIVERB_SHOW = -1,
        OLEIVERB_HIDE = -3,
        OLEIVERB_UIACTIVATE = -4,
        OLEIVERB_INPLACEACTIVATE = -5,
        OLEIVERB_PROPERTIES = -7,
        OLE_E_NOCONNECTION = unchecked((int)0x80040004),
        OLE_E_PROMPTSAVECANCELLED = unchecked((int)0x8004000C),
        OLEMISC_RECOMPOSEONRESIZE = 0x00000001,
        OLEMISC_INSIDEOUT = 0x00000080,
        OLEMISC_ACTIVATEWHENVISIBLE = 0x0000100,
        OLEMISC_ACTSLIKEBUTTON = 0x00001000,
        OLEMISC_SETCLIENTSITEFIRST = 0x00020000,
        OBJ_PEN = 1,
        OBJ_BRUSH = 2,
        OBJ_DC = 3,
        OBJ_METADC = 4,
        OBJ_PAL = 5,
        OBJ_FONT = 6,
        OBJ_BITMAP = 7,
        OBJ_REGION = 8,
        OBJ_METAFILE = 9,
        OBJ_MEMDC = 10,
        OBJ_EXTPEN = 11,
        OBJ_ENHMETADC = 12,
        ODS_CHECKED = 0x0008,
        ODS_COMBOBOXEDIT = 0x1000,
        ODS_DEFAULT = 0x0020,
        ODS_DISABLED = 0x0004,
        ODS_FOCUS = 0x0010,
        ODS_GRAYED = 0x0002,
        ODS_HOTLIGHT       = 0x0040,
        ODS_INACTIVE       = 0x0080,
        ODS_NOACCEL        = 0x0100,
        ODS_NOFOCUSRECT    = 0x0200,
        ODS_SELECTED = 0x0001,
        OLECLOSE_SAVEIFDIRTY = 0,
        OLECLOSE_PROMPTSAVE = 2;

        public const int PDERR_SETUPFAILURE = 0x1001,
        PDERR_PARSEFAILURE = 0x1002,
        PDERR_RETDEFFAILURE = 0x1003,
        PDERR_LOADDRVFAILURE = 0x1004,
        PDERR_GETDEVMODEFAIL = 0x1005,
        PDERR_INITFAILURE = 0x1006,
        PDERR_NODEVICES = 0x1007,
        PDERR_NODEFAULTPRN = 0x1008,
        PDERR_DNDMMISMATCH = 0x1009,
        PDERR_CREATEICFAILURE = 0x100A,
        PDERR_PRINTERNOTFOUND = 0x100B,
        PDERR_DEFAULTDIFFERENT = 0x100C,
        PD_NOSELECTION = 0x00000004,
        PD_NOPAGENUMS = 0x00000008,
        PD_NOCURRENTPAGE = 0x00800000,
        PD_COLLATE = 0x00000010,
        PD_PRINTTOFILE = 0x00000020,
        PD_SHOWHELP = 0x00000800,
        PD_ENABLEPRINTHOOK = 0x00001000,
        PD_DISABLEPRINTTOFILE = 0x00080000,
        PD_NONETWORKBUTTON = 0x00200000,
        PSD_MINMARGINS = 0x00000001,
        PSD_MARGINS = 0x00000002,
        PSD_INHUNDREDTHSOFMILLIMETERS = 0x00000008,
        PSD_DISABLEMARGINS = 0x00000010,
        PSD_DISABLEPRINTER = 0x00000020,
        PSD_DISABLEORIENTATION = 0x00000100,
        PSD_DISABLEPAPER = 0x00000200,
        PSD_SHOWHELP = 0x00000800,
        PSD_ENABLEPAGESETUPHOOK = 0x00002000,
        PSD_NONETWORKBUTTON = 0x00200000,
        PS_SOLID = 0,
        PS_DOT = 2,
        PLANES = 14,
        PRF_CHECKVISIBLE = 0x00000001,
        PRF_NONCLIENT = 0x00000002,
        PRF_CLIENT = 0x00000004,
        PRF_ERASEBKGND = 0x00000008,
        PRF_CHILDREN = 0x00000010,
        PM_NOREMOVE = 0x0000,
        PM_REMOVE = 0x0001,
        PM_NOYIELD = 0x0002,
        PBM_SETRANGE = (0x0400+1),
        PBM_SETPOS = (0x0400+2),
        PBM_SETSTEP = (0x0400+4),
        PBM_SETRANGE32 = (0x0400+6),
        PSM_SETTITLEA = (0x0400+111),
        PSM_SETTITLEW = (0x0400+120),
        PSM_SETFINISHTEXTA = (0x0400+115),
        PSM_SETFINISHTEXTW = (0x0400+121),
        PATCOPY = 0x00F00021,
        PATINVERT = 0x005A0049;

        public const int QS_KEY = 0x0001,
        QS_MOUSEMOVE = 0x0002,
        QS_MOUSEBUTTON = 0x0004,
        QS_POSTMESSAGE = 0x0008,
        QS_TIMER = 0x0010,
        QS_PAINT = 0x0020,
        QS_SENDMESSAGE = 0x0040,
        QS_HOTKEY = 0x0080,
        QS_ALLPOSTMESSAGE = 0x0100,
        QS_MOUSE = QS_MOUSEMOVE | QS_MOUSEBUTTON,
        QS_INPUT = QS_MOUSE | QS_KEY,
        QS_ALLEVENTS = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY,
        QS_ALLINPUT = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE;

        
    //public const int RECO_PASTE = 0x00000000;   // paste from clipboard
    public const int RECO_DROP  = 0x00000001;    // drop
    //public const int RECO_COPY  = 0x00000002;    // copy to the clipboard
    //public const int RECO_CUT   = 0x00000003; // cut to the clipboard
    //public const int RECO_DRAG  = 0x00000004;    // drag
        
    public const int RPC_E_CHANGED_MODE = unchecked((int)0x80010106),
        RGN_DIFF = 4,
        RDW_INVALIDATE = 0x0001,
        RDW_ERASE = 0x0004,
        RDW_ALLCHILDREN = 0x0080,
        RDW_FRAME = 0x0400,
        RB_INSERTBANDA = (0x0400+1),
        RB_INSERTBANDW = (0x0400+10);
        
        public const int stc4 = 0x0443,
        SHGFP_TYPE_CURRENT = 0,
        STGM_READ = 0x00000000,
        STGM_WRITE = 0x00000001,
        STGM_READWRITE = 0x00000002,
        STGM_SHARE_EXCLUSIVE = 0x00000010,
        STGM_CREATE = 0x00001000,
        STARTF_USESHOWWINDOW = 0x00000001,
        SB_HORZ = 0,
        SB_VERT = 1,
        SB_CTL = 2,
        SB_LINEUP = 0,
        SB_LINELEFT = 0,
        SB_LINEDOWN = 1,
        SB_LINERIGHT = 1,
        SB_PAGEUP = 2,
        SB_PAGELEFT = 2,
        SB_PAGEDOWN = 3,
        SB_PAGERIGHT = 3,
        SB_THUMBPOSITION = 4,
        SB_THUMBTRACK = 5,
        SB_LEFT = 6,
        SB_RIGHT = 7,
        SB_ENDSCROLL = 8,
        SB_TOP = 6,
        SB_BOTTOM = 7,
        SORT_DEFAULT =0x0,
        SUBLANG_DEFAULT = 0x01,
        SW_HIDE = 0,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_MAX = 10,
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_NOZORDER = 0x0004,
        SWP_NOACTIVATE = 0x0010,
        SWP_SHOWWINDOW = 0x0040,
        SWP_HIDEWINDOW = 0x0080,
        SWP_DRAWFRAME = 0x0020,
        SM_CXSCREEN = 0,
        SM_CYSCREEN = 1,
        SM_CXVSCROLL = 2,
        SM_CYHSCROLL = 3,
        SM_CYCAPTION = 4,
        SM_CXBORDER = 5,
        SM_CYBORDER = 6,
        SM_CYVTHUMB = 9,
        SM_CXHTHUMB = 10,
        SM_CXICON = 11,
        SM_CYICON = 12,
        SM_CXCURSOR = 13,
        SM_CYCURSOR = 14,
        SM_CYMENU = 15,
        SM_CYKANJIWINDOW = 18,
        SM_MOUSEPRESENT = 19,
        SM_CYVSCROLL = 20,
        SM_CXHSCROLL = 21,
        SM_DEBUG = 22,
        SM_SWAPBUTTON = 23,
        SM_CXMIN = 28,
        SM_CYMIN = 29,
        SM_CXSIZE = 30,
        SM_CYSIZE = 31,
        SM_CXFRAME = 32,
        SM_CYFRAME = 33,
        SM_CXMINTRACK = 34,
        SM_CYMINTRACK = 35,
        SM_CXDOUBLECLK = 36,
        SM_CYDOUBLECLK = 37,
        SM_CXICONSPACING = 38,
        SM_CYICONSPACING = 39,
        SM_MENUDROPALIGNMENT = 40,
        SM_PENWINDOWS = 41,
        SM_DBCSENABLED = 42,
        SM_CMOUSEBUTTONS = 43,
        SM_CXFIXEDFRAME = 7,
        SM_CYFIXEDFRAME = 8,
        SM_SECURE = 44,
        SM_CXEDGE = 45,
        SM_CYEDGE = 46,
        SM_CXMINSPACING = 47,
        SM_CYMINSPACING = 48,
        SM_CXSMICON = 49,
        SM_CYSMICON = 50,
        SM_CYSMCAPTION = 51,
        SM_CXSMSIZE = 52,
        SM_CYSMSIZE = 53,
        SM_CXMENUSIZE = 54,
        SM_CYMENUSIZE = 55,
        SM_ARRANGE = 56,
        SM_CXMINIMIZED = 57,
        SM_CYMINIMIZED = 58,
        SM_CXMAXTRACK = 59,
        SM_CYMAXTRACK = 60,
        SM_CXMAXIMIZED = 61,
        SM_CYMAXIMIZED = 62,
        SM_NETWORK = 63,
        SM_CLEANBOOT = 67,
        SM_CXDRAG = 68,
        SM_CYDRAG = 69,
        SM_SHOWSOUNDS = 70,
        SM_CXMENUCHECK = 71,
        SM_CYMENUCHECK = 72,
        SM_MIDEASTENABLED = 74,
        SM_MOUSEWHEELPRESENT = 75,
        SM_XVIRTUALSCREEN = 76,
        SM_YVIRTUALSCREEN = 77,
        SM_CXVIRTUALSCREEN = 78,
        SM_CYVIRTUALSCREEN = 79,
        SM_CMONITORS = 80,
        SM_SAMEDISPLAYFORMAT = 81,
        SM_REMOTESESSION = 0x1000;
        
        public const int SW_SCROLLCHILDREN = 0x0001,
        SW_INVALIDATE = 0x0002,
        SW_ERASE = 0x0004,
        SC_SIZE = 0xF000,
        SC_MINIMIZE = 0xF020,
        SC_MAXIMIZE = 0xF030,
        SC_CLOSE = 0xF060,
        SC_KEYMENU = 0xF100,
        SC_RESTORE = 0xF120,
        SS_LEFT = 0x00000000,
        SS_CENTER = 0x00000001,
        SS_RIGHT = 0x00000002,
        SS_OWNERDRAW = 0x0000000D,
        SS_NOPREFIX = 0x00000080,
        SS_SUNKEN = 0x00001000,
        SBS_HORZ = 0x0000,
        SBS_VERT = 0x0001,
        SIF_RANGE = 0x0001,
        SIF_PAGE = 0x0002,
        SIF_POS = 0x0004,
        SIF_TRACKPOS = 0x0010,
        SIF_ALL = (0x0001|0x0002|0x0004|0x0010),
        SPI_GETDRAGFULLWINDOWS = 38,
        SPI_GETNONCLIENTMETRICS = 41,
        SPI_GETWORKAREA = 48,
        SPI_GETHIGHCONTRAST = 66,
        SPI_GETDEFAULTINPUTLANG = 89,
        SPI_GETSNAPTODEFBUTTON = 95,
        SPI_GETWHEELSCROLLLINES = 104,
        SBARS_SIZEGRIP = 0x0100,
        SB_SETTEXTA = (0x0400+1),
        SB_SETTEXTW = (0x0400+11),
        SB_GETTEXTA = (0x0400+2),
        SB_GETTEXTW = (0x0400+13),
        SB_GETTEXTLENGTHA = (0x0400+3),
        SB_GETTEXTLENGTHW = (0x0400+12),
        SB_SETPARTS = (0x0400+4),
        SB_SIMPLE = (0x0400+9),
        SB_GETRECT = (0x0400+10),
        SB_SETICON = (0x0400+15),
        SB_SETTIPTEXTA = (0x0400+16),
        SB_SETTIPTEXTW = (0x0400+17),
        SB_GETTIPTEXTA = (0x0400+18),
        SB_GETTIPTEXTW = (0x0400+19),
        SBT_OWNERDRAW = 0x1000,
        SBT_NOBORDERS = 0x0100,
        SBT_POPOUT = 0x0200,
        SBT_RTLREADING = 0x0400,
        SRCCOPY = 0x00CC0020,
        STATFLAG_DEFAULT = 0x0,
        STATFLAG_NONAME = 0x1,
        STATFLAG_NOOPEN = 0x2,
        STGC_DEFAULT = 0x0,
        STGC_OVERWRITE = 0x1,
        STGC_ONLYIFCURRENT = 0x2,
        STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 0x4,
        STREAM_SEEK_SET = 0x0,
        STREAM_SEEK_CUR = 0x1,
        STREAM_SEEK_END = 0x2;

        public const int S_OK =      0x00000000;
        public const int S_FALSE =   0x00000001;

        public static bool Succeeded(int hr) {
            return(hr >= 0);
        }

        public static bool Failed(int hr) {
            return(hr < 0);
        }

        public const int TRANSPARENT = 1,
        TME_HOVER = 0x00000001,
        TME_LEAVE = 0x00000002,
        TPM_LEFTBUTTON = 0x0000,
        TPM_LEFTALIGN = 0x0000,
        TPM_VERTICAL = 0x0040,
        TV_FIRST = 0x1100,
        TBSTATE_CHECKED = 0x01,
        TBSTATE_ENABLED = 0x04,
        TBSTATE_HIDDEN = 0x08,
        TBSTATE_INDETERMINATE = 0x10,
        TBSTYLE_BUTTON = 0x00,
        TBSTYLE_SEP = 0x01,
        TBSTYLE_





































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































*/
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(int left, int top, int right, int bottom) {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public static RECT FromXYWH(int x, int y, int width, int height) {
                return new RECT(x, y, x + width, y + height);
            }
        }
/*        public delegate int ListViewCompareCallback(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class WNDCLASS {
            public int      style = 0;
            public IntPtr   lpfnWndProc = IntPtr.Zero;
            public int      cbClsExtra = 0;
            public int      cbWndExtra = 0;
            public IntPtr   hInstance = IntPtr.Zero;
            public IntPtr   hIcon = IntPtr.Zero;
            public IntPtr   hCursor = IntPtr.Zero;
            public IntPtr   hbrBackground = IntPtr.Zero;
            public string   lpszMenuName = null;
            public string   lpszClassName = null;
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class WNDCLASS_I {
            public int      style = 0;
            public IntPtr   lpfnWndProc = IntPtr.Zero;
            public int      cbClsExtra = 0;
            public int      cbWndExtra = 0;
            public IntPtr   hInstance = IntPtr.Zero;
            public IntPtr   hIcon = IntPtr.Zero;
            public IntPtr   hCursor = IntPtr.Zero;
            public IntPtr   hbrBackground = IntPtr.Zero;
            public IntPtr   lpszMenuName = IntPtr.Zero;
            public IntPtr   lpszClassName = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class WNDCLASSEX_I {
            public int      cbSize = 0;
            public int      style = 0;
            public IntPtr   lpfnWndProc = IntPtr.Zero;
            public int      cbClsExtra = 0;
            public int      cbWndExtra = 0;
            public IntPtr   hInstance = IntPtr.Zero;
            public IntPtr   hIcon = IntPtr.Zero;
            public IntPtr   hCursor = IntPtr.Zero;
            public IntPtr   hbrBackground = IntPtr.Zero;
            public IntPtr   lpszMenuName = IntPtr.Zero;
            public IntPtr   lpszClassName = IntPtr.Zero;
            public IntPtr   hIconSm = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class NONCLIENTMETRICS {
            public int      cbSize = Marshal.SizeOf(typeof(NONCLIENTMETRICS));
            public int      iBorderWidth = 0; 
            public int      iScrollWidth = 0; 
            public int      iScrollHeight = 0; 
            public int      iCaptionWidth = 0; 
            public int      iCaptionHeight = 0; 
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT  lfCaptionFont = null; 
            public int      iSmCaptionWidth = 0; 
            public int      iSmCaptionHeight = 0; 
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT  lfSmCaptionFont = null; 
            public int      iMenuWidth = 0; 
            public int      iMenuHeight = 0; 
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT  lfMenuFont =  null; 
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT  lfStatusFont = null; 
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT  lfMessageFont = null; 
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG {
            public IntPtr   hwnd;
            public int      message;
            public IntPtr   wParam;
            public IntPtr   lParam;
            public int      time;
            // pt was a by-value POINT structure
            public int      pt_x;
            public int      pt_y;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct PAINTSTRUCT {
            public IntPtr   hdc;
            public bool     fErase;
            // rcPaint was a by-value RECT structure
            public int      rcPaint_left;
            public int      rcPaint_top;
            public int      rcPaint_right;
            public int      rcPaint_bottom;
            public bool     fRestore;
            public bool     fIncUpdate;    
            public int      reserved1;
            public int      reserved2;
            public int      reserved3;
            public int      reserved4;
            public int      reserved5;
            public int      reserved6;
            public int      reserved7;
            public int      reserved8;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class SCROLLINFO {
            public int cbSize = Marshal.SizeOf(typeof(SCROLLINFO));
            public int fMask = 0;
            public int nMin = 0;
            public int nMax = 0;
            public int nPage = 0;
            public int nPos = 0;
            public int nTrackPos = 0;
            
            public SCROLLINFO() {
            }

            public SCROLLINFO(int mask, int min, int max, int page, int pos) {
                fMask = mask;
                nMin = min;
                nMax = max;
                nPage = page;
                nPos = pos;
            }
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class TPMPARAMS {
            public int  cbSize = Marshal.SizeOf(typeof(TPMPARAMS));
            // rcExclude was a by-value RECT structure
            public int  rcExclude_left = 0;
            public int  rcExclude_top = 0;
            public int  rcExclude_right = 0;
            public int  rcExclude_bottom = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class SIZE {
            public int cx = 0;
            public int cy = 0;
            
            public SIZE() {
            }

            public SIZE(int cx, int cy) {
                this.cx = cx;
                this.cy = cy;
            }
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT {
            public int  length;
            public int  flags;
            public int  showCmd;
            // ptMinPosition was a by-value POINT structure
            public int  ptMinPosition_x;
            public int  ptMinPosition_y;
            // ptMaxPosition was a by-value POINT structure
            public int  ptMaxPosition_x;
            public int  ptMaxPosition_y;
            // rcNormalPosition was a by-value RECT structure
            public int  rcNormalPosition_left;
            public int  rcNormalPosition_top;
            public int  rcNormalPosition_right;
            public int  rcNormalPosition_bottom;
        }
        
        [StructLayout(LayoutKind.Sequential,CharSet=CharSet.Auto)]
        public class STARTUPINFO {
            public int      cb = 0;
            public string   lpReserved = null;
            public string   lpDesktop = null;
            public string   lpTitle = null;
            public int      dwX = 0;
            public int      dwY = 0;
            public int      dwXSize = 0;
            public int      dwYSize = 0;
            public int      dwXCountChars = 0;
            public int      dwYCountChars = 0;
            public int      dwFillAttribute = 0;
            public int      dwFlags = 0;
            public short    wShowWindow = 0;
            public short    cbReserved2 = 0;
            public IntPtr   lpReserved2 = IntPtr.Zero;
            public IntPtr   hStdInput = IntPtr.Zero;
            public IntPtr   hStdOutput = IntPtr.Zero;
            public IntPtr   hStdError = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential,CharSet=CharSet.Auto)]
        public class STARTUPINFO_I {
            public int      cb = 0;
            public IntPtr   lpReserved = IntPtr.Zero;
            public IntPtr   lpDesktop = IntPtr.Zero;
            public IntPtr   lpTitle = IntPtr.Zero;
            public int      dwX = 0;
            public int      dwY = 0;
            public int      dwXSize = 0;
            public int      dwYSize = 0;
            public int      dwXCountChars = 0;
            public int      dwYCountChars = 0;
            public int      dwFillAttribute = 0;
            public int      dwFlags = 0;
            public short    wShowWindow = 0;
            public short    cbReserved2 = 0;
            public IntPtr   lpReserved2 = IntPtr.Zero;
            public IntPtr   hStdInput = IntPtr.Zero;
            public IntPtr   hStdOutput = IntPtr.Zero;
            public IntPtr   hStdError = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class PAGESETUPDLG {
            public int      lStructSize = 0; 
            public IntPtr   hwndOwner = IntPtr.Zero; 
            public IntPtr   hDevMode = IntPtr.Zero; 
            public IntPtr   hDevNames = IntPtr.Zero; 
            public int      Flags = 0; 

            //POINT           ptPaperSize; 
            public int      paperSizeX = 0;
            public int      paperSizeY = 0;

            // RECT            rtMinMargin; 
            public int      minMarginLeft = 0;
            public int      minMarginTop = 0;
            public int      minMarginRight = 0;
            public int      minMarginBottom = 0;

            // RECT            rtMargin; 
            public int      marginLeft = 0;
            public int      marginTop = 0;
            public int      marginRight = 0;
            public int      marginBottom = 0;

            public IntPtr   hInstance = IntPtr.Zero; 
            public IntPtr   lCustData = IntPtr.Zero; 
            public WndProc  lpfnPageSetupHook = null; 
            public WndProc  lpfnPagePaintHook = null; 
            public string   lpPageSetupTemplateName = null; 
            public IntPtr   hPageSetupTemplate = IntPtr.Zero; 
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public class PRINTDLG {
            public   int    lStructSize = 0;
            public   IntPtr hwndOwner = IntPtr.Zero;
            public   IntPtr hDevMode = IntPtr.Zero;
            public   IntPtr hDevNames = IntPtr.Zero;
            public   IntPtr hDC = IntPtr.Zero;
            public   int    Flags = 0;
            public   short  nFromPage = 0;
            public   short  nToPage = 0;
            public   short  nMinPage = 0;
            public   short  nMaxPage = 0;
            public   short  nCopies = 0;
            public   IntPtr hInstance = IntPtr.Zero;
            public   IntPtr lCustData = IntPtr.Zero;
            public   WndProc lpfnPrintHook = null;
            public   WndProc lpfnSetupHook = null;
            public   string lpPrintTemplateName = null;
            public   string lpSetupTemplateName = null;
            public   IntPtr hPrintTemplate = IntPtr.Zero;
            public   IntPtr hSetupTemplate = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class PICTDESC
        {
            internal int cbSizeOfStruct;
            public int picType;
            internal IntPtr union1;
            internal int union2;
            internal int union3;

            public static PICTDESC CreateBitmapPICTDESC(IntPtr hbitmap, IntPtr hpal) {
                PICTDESC pictdesc = new PICTDESC();
                pictdesc.cbSizeOfStruct = 16;
                pictdesc.picType = Ole.PICTYPE_BITMAP;
                pictdesc.union1 = hbitmap;
                pictdesc.union2 = (int)(((long)hpal) & 0xffffffff);
                pictdesc.union3 = (int)(((long)hpal) >> 32);
                return pictdesc;
            }

            public static PICTDESC CreateIconPICTDESC(IntPtr hicon) {
                PICTDESC pictdesc = new PICTDESC();
                pictdesc.cbSizeOfStruct = 12;
                pictdesc.picType = Ole.PICTYPE_ICON;
                pictdesc.union1 = hicon;
                return pictdesc;
            }

            public static PICTDESC CreateEnhMetafilePICTDESC(IntPtr hEMF) {
                PICTDESC pictdesc = new PICTDESC();
                pictdesc.cbSizeOfStruct = 12;
                pictdesc.picType = Ole.PICTYPE_ENHMETAFILE;
                pictdesc.union1 = hEMF;
                return pictdesc;
            }

            public static PICTDESC CreateWinMetafilePICTDESC(IntPtr hmetafile, int x, int y) {
                PICTDESC pictdesc = new PICTDESC();
                pictdesc.cbSizeOfStruct = 20;
                pictdesc.picType = Ole.PICTYPE_METAFILE;
                pictdesc.union1 = hmetafile;
                pictdesc.union2 = x;
                pictdesc.union3 = y;
                return pictdesc;
            }

            public virtual IntPtr GetHandle() {
                return union1;
            }

            public virtual IntPtr GetHPal() {
                if (picType == Ole.PICTYPE_BITMAP)
                    return (IntPtr)((uint) union2 | (uint) (((long)union3) << 32));
                else
                    return IntPtr.Zero;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public  sealed class tagFONTDESC {
             public int cbSizeofstruct = Marshal.SizeOf(typeof(tagFONTDESC)); 
             
             [MarshalAs(UnmanagedType.LPWStr)]
             public string lpstrName = null; 
             
             [MarshalAs(UnmanagedType.U8)] 
             public long cySize = 0; 
             
             [MarshalAs(UnmanagedType.U2)] 
             public short sWeight = 0; 
             
             [MarshalAs(UnmanagedType.U2)] 
             public short sCharset = 0;
             
             [MarshalAs(UnmanagedType.Bool)] 
             public bool  fItalic = false; 
             
             [MarshalAs(UnmanagedType.Bool)] 
             public bool  fUnderline = false; 
             
             [MarshalAs(UnmanagedType.Bool)] 
             public bool fStrikethrough = false; 
        }


        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public class CHOOSECOLOR {
            public int      lStructSize = 36; //ndirect.DllLib.sizeOf(this);
            public IntPtr   hwndOwner = IntPtr.Zero;
            public IntPtr   hInstance = IntPtr.Zero;
            public int      rgbResult = 0;
            public IntPtr   lpCustColors = IntPtr.Zero;
            public int      Flags = 0;
            public IntPtr   lCustData = IntPtr.Zero;
            public WndProc  lpfnHook = null;
            public string   lpTemplateName = null;
        }
        
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        
        [StructLayout(LayoutKind.Sequential)]
        public class BITMAP {
            public int bmType = 0;
            public int bmWidth = 0;
            public int bmHeight = 0;
            public int bmWidthBytes = 0;
            public short bmPlanes = 0;
            public short bmBitsPixel = 0;
            public int bmBits = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class DIBSECTION {
            public BITMAP dsBm = null;
            public BITMAPINFOHEADER dsBmih = null;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
            public int[] dsBitfields = null;
            public IntPtr dshSection = IntPtr.Zero;
            public int dsOffset = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class LOGPEN {
            public int  lopnStyle = 0;
            // lopnWidth was a by-value POINT structure
            public int  lopnWidth_x = 0;
            public int  lopnWidth_y = 0;
            public int  lopnColor = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class LOGBRUSH {
                public int lbStyle = 0;
                public int lbColor = 0;
                public IntPtr lbHatch = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class LOGFONT {
            public int lfHeight = 0;
            public int lfWidth = 0;
            public int lfEscapement = 0;
            public int lfOrientation = 0;
            public int lfWeight = 0;
            public byte lfItalic = 0;
            public byte lfUnderline = 0;
            public byte lfStrikeOut = 0;
            public byte lfCharSet = 0;
            public byte lfOutPrecision = 0;
            public byte lfClipPrecision = 0;
            public byte lfQuality = 0;
            public byte lfPitchAndFamily = 0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
            public string   lfFaceName = null;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class LOGPALETTE {
            public short palVersion = 0;
            public short palNumEntries = 0;
            public int palPalEntry = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class TEXTMETRIC {
            public int tmHeight = 0;
            public int tmAscent = 0;
            public int tmDescent = 0;
            public int tmInternalLeading = 0;
            public int tmExternalLeading = 0;
            public int tmAveCharWidth = 0;
            public int tmMaxCharWidth = 0;
            public int tmWeight = 0;
            public int tmOverhang = 0;
            public int tmDigitizedAspectX = 0;
            public int tmDigitizedAspectY = 0;
            public char tmFirstChar = '\0';
            public char tmLastChar = '\0';
            public char tmDefaultChar = '\0';
            public char tmBreakChar = '\0';
            public byte tmItalic = 0;
            public byte tmUnderlined = 0;
            public byte tmStruckOut = 0;
            public byte tmPitchAndFamily = 0;
            public byte tmCharSet = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public class NOTIFYICONDATA {
            public int      cbSize = Marshal.SizeOf(typeof(NOTIFYICONDATA));
            public IntPtr   hWnd = IntPtr.Zero;
            public int      uID = 0;
            public int      uFlags = 0;
            public int      uCallbackMessage = 0;
            public IntPtr   hIcon = IntPtr.Zero;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=64)]
            public string   szTip = null;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class MENUITEMINFO_T
        {
            public int      cbSize = Marshal.SizeOf(typeof(MENUITEMINFO_T));
            public int      fMask = 0;
            public int      fType = 0;
            public int      fState = 0;
            public int      wID = 0;
            public IntPtr   hSubMenu = IntPtr.Zero;
            public IntPtr   hbmpChecked = IntPtr.Zero;
            public IntPtr   hbmpUnchecked = IntPtr.Zero;
            public int      dwItemData = 0;
            public string   dwTypeData = null;
            public int      cch = 0;
        }
        
        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public class OPENFILENAME_I
        {
            public int      lStructSize = 0x58; //ndirect.DllLib.sizeOf(this);
            public IntPtr   hwndOwner = IntPtr.Zero;
            public IntPtr   hInstance = IntPtr.Zero;
            public string   lpstrFilter = null;   // use embedded nulls to separate filters
            public IntPtr   lpstrCustomFilter = IntPtr.Zero;
            public int      nMaxCustFilter = 0;
            public int      nFilterIndex = 0;
            public IntPtr   lpstrFile = IntPtr.Zero;
            public int      nMaxFile = NativeMethods.MAX_PATH;
            public IntPtr   lpstrFileTitle = IntPtr.Zero;
            public int      nMaxFileTitle = NativeMethods.MAX_PATH;
            public string   lpstrInitialDir = null;
            public string   lpstrTitle = null;
            public int      Flags = 0;
            public short    nFileOffset = 0;
            public short    nFileExtension = 0;
            public string   lpstrDefExt = null;
            public IntPtr   lCustData = IntPtr.Zero;
            public WndProc  lpfnHook = null;
            public string   lpTemplateName = null;
            public IntPtr   pvReserved = IntPtr.Zero;
            public int      dwReserved = 0;
            public int      FlagsEx = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto), CLSCompliantAttribute(false)]
        public class CHOOSEFONT {
            public int      lStructSize = 60;   // ndirect.DllLib.sizeOf(this);
            public IntPtr   hwndOwner = IntPtr.Zero;
            public IntPtr   hDC = IntPtr.Zero;
            public IntPtr   lpLogFont = IntPtr.Zero;
            public int      iPointSize = 0;
            public int      Flags = 0;
            public int      rgbColors = 0;
            public IntPtr   lCustData = IntPtr.Zero;
            public WndProc  lpfnHook = null;
            public string   lpTemplateName = null;
            public IntPtr   hInstance = IntPtr.Zero;
            public string   lpszStyle = null;
            public short    nFontType = 0;
            public short    ___MISSING_ALIGNMENT__ = 0;
            public int      nSizeMin = 0;
            public int      nSizeMax = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFO {
            // bmiHeader was a by-value BITMAPINFOHEADER structure
            public int      bmiHeader_biSize = 40;  // ndirect.DllLib.sizeOf( BITMAPINFOHEADER.class );
            public int      bmiHeader_biWidth = 0;
            public int      bmiHeader_biHeight = 0;
            public short    bmiHeader_biPlanes = 0;
            public short    bmiHeader_biBitCount = 0;
            public int      bmiHeader_biCompression = 0;
            public int      bmiHeader_biSizeImage = 0;
            public int      bmiHeader_biXPelsPerMeter = 0;
            public int      bmiHeader_biYPelsPerMeter = 0;
            public int      bmiHeader_biClrUsed = 0;
            public int      bmiHeader_biClrImportant = 0;

            // bmiColors was an embedded array of RGBQUAD structures
            public byte     bmiColors_rgbBlue = 0;
            public byte     bmiColors_rgbGreen = 0;
            public byte     bmiColors_rgbRed = 0;
            public byte     bmiColors_rgbReserved = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFOHEADER {
            public int      biSize = 40;    // ndirect.DllLib.sizeOf( this );
            public int      biWidth = 0;
            public int      biHeight = 0;
            public short    biPlanes = 0;
            public short    biBitCount = 0;
            public int      biCompression = 0;
            public int      biSizeImage = 0;
            public int      biXPelsPerMeter = 0;
            public int      biYPelsPerMeter = 0;
            public int      biClrUsed = 0;
            public int      biClrImportant = 0;
        }
        
        public class Ole {
            public const int PICTYPE_UNINITIALIZED = -1;
            public const int PICTYPE_NONE          =  0;
            public const int PICTYPE_BITMAP        =  1;
            public const int PICTYPE_METAFILE      =  2;
            public const int PICTYPE_ICON          =  3;
            public const int PICTYPE_ENHMETAFILE   =  4;
            public const int STATFLAG_DEFAULT = 0;
            public const int STATFLAG_NONAME = 1;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public sealed class FORMATETC {
            public   short cfFormat = 0;
            public   short dummy = 0;
            public   IntPtr ptd = IntPtr.Zero;
            public   int dwAspect = 0;
            public   int lindex = 0;
            public   int tymed = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class STATSTG {

            [MarshalAs(UnmanagedType.LPWStr)]
            public   string pwcsName = null;
            
            public   int type = 0;
            [MarshalAs(UnmanagedType.I8)]
            public   long cbSize = 0;
            [MarshalAs(UnmanagedType.I8)]
            public   long mtime = 0;
            [MarshalAs(UnmanagedType.I8)]
            public   long ctime = 0;
            [MarshalAs(UnmanagedType.I8)]
            public   long atime = 0;
            [MarshalAs(UnmanagedType.I4)]
            public   int grfMode = 0;
            [MarshalAs(UnmanagedType.I4)]
            public   int grfLocksSupported = 0;
            
            public   int clsid_data1 = 0;
            [MarshalAs(UnmanagedType.I2)]
            public   short clsid_data2 = 0;
            [MarshalAs(UnmanagedType.I2)]
            public   short clsid_data3 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public   byte clsid_b0 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public   byte clsid_b1 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public   byte clsid_b2 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public   byte clsid_b3 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public   byte clsid_b4 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public   byte clsid_b5 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public   byte clsid_b6 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public   byte clsid_b7 = 0;
            [MarshalAs(UnmanagedType.I4)]
            public   int grfStateBits = 0;
            [MarshalAs(UnmanagedType.I4)]
            public   int reserved = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class FILETIME {
            public int dwLowDateTime = 0;
            public int dwHighDateTime = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class OVERLAPPED {
            public int Internal = 0;
            public int InternalHigh = 0;
            public int Offset = 0;
            public int OffsetHigh = 0;
            public IntPtr hEvent = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class SYSTEMTIME {
            public short wYear = 0;
            public short wMonth = 0;
            public short wDayOfWeek = 0;
            public short wDay = 0;
            public short wHour = 0;
            public short wMinute = 0;
            public short wSecond = 0;
            public short wMilliseconds = 0;

            public override string ToString() {
                return "[SYSTEMTIME: " 
                + wDay.ToString() +"/" + wMonth.ToString() + "/" + wYear.ToString() 
                + " " + wHour.ToString() + ":" + wMinute.ToString() + ":" + wSecond.ToString()
                + "]";
            }
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class STGMEDIUM {
            public   int tymed = 0;
            public   IntPtr unionmember = IntPtr.Zero;
            public   IntPtr pUnkForRelease = IntPtr.Zero;
        }
        
        [
        StructLayout(LayoutKind.Sequential),
        CLSCompliantAttribute(false)
        ]
        public sealed class  _POINTL {
            public   int x = 0;
            public   int y = 0;

        }
        
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagSIZE {
            public   int cx = 0;
            public   int cy = 0;

        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class COMRECT {
            public int left = 0;
            public int top = 0;
            public int right = 0;
            public int bottom = 0;
            
            public COMRECT() {
            }

            public COMRECT(int left, int top, int right, int bottom) {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public static COMRECT FromXYWH(int x, int y, int width, int height) {
                return new COMRECT(x, y, x + width, y + height);
            }

            public override string ToString() {
                return "Left = " + left + " Top " + top + " Right = " + right + " Bottom = " + bottom;
            }
        }
        
        [StructLayout(LayoutKind.Sequential)] // leftover(noAutoOffset)
        public sealed class tagOleMenuGroupWidths {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)] // leftover(offset=0, widths)
            public int[] widths = new int[6];
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class MSOCRINFOSTRUCT {
            public int cbSize = Marshal.SizeOf(typeof(MSOCRINFOSTRUCT));              // size of MSOCRINFO structure in bytes.
            public int uIdleTimeInterval = 0;   // If olecrfNeedPeriodicIdleTime is registered
                                            // in grfcrf, component needs to perform
                                            // periodic idle time tasks during an idle phase
                                            // every uIdleTimeInterval milliseconds.
            public int grfcrf = 0;              // bit flags taken from olecrf values (above)
            public int grfcadvf = 0;            // bit flags taken from olecadvf values (above)
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct NMLISTVIEW
        {
            public NMHDR hdr;
            public int   iItem;
            public int   iSubItem;
            public int   uNewState;
            public int   uOldState;
            public int   uChanged;
            public IntPtr lParam;
        }
        
        public class ConnectionPointCookie
        {
            private UnsafeNativeMethods.IConnectionPoint connectionPoint;
            private int cookie;
            #if DEBUG
            private string callStack;
            #endif
    
            /// <devdoc>
            /// Creates a connection point to of the given interface type.
            /// which will call on a managed code sink that implements that interface.
            /// </devdoc>
            public ConnectionPointCookie(object source, object sink, Type eventInterface) : this(source, sink, eventInterface, true){
            }
    
            /// <devdoc>
            /// Creates a connection point to of the given interface type.
            /// which will call on a managed code sink that implements that interface.
            /// </devdoc>
            public ConnectionPointCookie(object source, object sink, Type eventInterface, bool throwException){
                Exception ex = null;
                if (source is UnsafeNativeMethods.IConnectionPointContainer) {
                    UnsafeNativeMethods.IConnectionPointContainer cpc = (UnsafeNativeMethods.IConnectionPointContainer)source;
    
                    try {
                        Guid tmp = eventInterface.GUID;
                        connectionPoint = cpc.FindConnectionPoint(ref tmp);
                    }
                    catch (Exception) {
                        connectionPoint = null;
                    }
    
                    if (connectionPoint == null) {
                        ex = new ArgumentException("SR.GetString(SR.ConnPointSourceIF, eventInterface.Name )");
                    }
                    else if (sink == null || !eventInterface.IsInstanceOfType(sink)) {
                        ex = new InvalidCastException("SR.GetString(SR.ConnPointSinkIF)");
                    }
                    else {
                        int hr = connectionPoint.Advise(sink, ref cookie);
                        if (hr != S_OK) {
                            cookie = 0;
                            Marshal.ReleaseComObject(connectionPoint);
                            connectionPoint = null;
                            ex = new ExternalException("SR.GetString(SR.ConnPointAdviseFailed, eventInterface.Name, hr )");
                        }
                    }
                }
                else {
                    ex = new InvalidCastException("SR.GetString(SR.ConnPointSourceIF, \"IConnectionPointContainer\")");
                }
    
    
                if (throwException && (connectionPoint == null || cookie == 0)) {
                    if (connectionPoint != null) {
                        Marshal.ReleaseComObject(connectionPoint);
                    }

                    if (ex == null) {
                        throw new ArgumentException("SR.GetString(SR.ConnPointCouldNotCreate, eventInterface.Name )");
                    }
                    else {
                        throw ex;
                    }
                }
                
                #if DEBUG
                callStack = Environment.StackTrace;
                #endif
            }
    
            /// <devdoc>
            /// Disconnect the current connection point.  If the object is not connected,
            /// this method will do nothing.
            /// </devdoc>
            public void Disconnect() {
                Disconnect(false);
            }
    
            /// <devdoc>
            /// Disconnect the current connection point.  If the object is not connected,
            /// this method will do nothing.
            /// </devdoc>
            public void Disconnect(bool release) {
                if (connectionPoint != null && cookie != 0) {
                    connectionPoint.Unadvise(cookie);
                    cookie = 0;
    
                    if (release) {
                        Marshal.ReleaseComObject(connectionPoint);
                    }
    
                    connectionPoint = null;
                }
            }
    
            /// <internalonly/>
            ~ConnectionPointCookie(){
                System.Diagnostics.Debug.Assert(connectionPoint == null || cookie == 0, "We should never finalize an active connection point");
                Disconnect();
            }
        }

        [StructLayout(LayoutKind.Sequential)] //leftover(noAutoOffset)
        public sealed class tagPOINTF
        {
          [MarshalAs(UnmanagedType.R4)] //leftover(offset=0, x)
          public float x = 0.0f;

          [MarshalAs(UnmanagedType.R4)] //leftover(offset=4, y)
          public float y = 0.0f;

        }

        [StructLayout(LayoutKind.Sequential)] //leftover(noAutoOffset)
        public sealed class tagOIFI
        {
          [MarshalAs(UnmanagedType.U4)] //leftover(offset=0, cb)
          public int cb = 0;
          
          public int fMDIApp = 0;
          public IntPtr hwndFrame = IntPtr.Zero;
          public IntPtr hAccel = IntPtr.Zero;

          [MarshalAs(UnmanagedType.U4)] //leftover(offset=16, cAccelEntries)
          public int cAccelEntries = 0;

        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR
        {
            public IntPtr hwndFrom;
            public int idFrom;
            public int code;
        }
        
        [ComVisible(true),Guid("626FC520-A41E-11CF-A731-00A0C9082637"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        internal interface IHTMLDocument {

            [return: MarshalAs(UnmanagedType.Interface)]
              object GetScript();

        }

        [ComImport(), Guid("376BD3AA-3845-101B-84ED-08002B2EC713"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPerPropertyBrowsing {
             [PreserveSig]
             int GetDisplayString(
                int dispID,
                [Out, MarshalAs(UnmanagedType.LPArray)]
                string[] pBstr);
            
             [PreserveSig]
             int MapPropertyToPage(
                int dispID,
                [Out]
                out Guid pGuid);
            
             [PreserveSig]
             int GetPredefinedStrings(
                int dispID,
                [Out]
                CA_STRUCT pCaStringsOut,
                [Out]
                CA_STRUCT pCaCookiesOut);

             [PreserveSig]
             int GetPredefinedValue(
                int dispID,
                [In, MarshalAs(UnmanagedType.U4)]
                int dwCookie,
                [Out]
                VARIANT pVarOut);
        }
        
        [ComImport(), Guid("4D07FC10-F931-11CE-B001-00AA006884E5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICategorizeProperties {
            
             [PreserveSig]
             int MapPropertyToCategory(
                int dispID,
                ref int categoryID);

             [PreserveSig]
             int GetCategoryName(
                int propcat,
                [In, MarshalAs(UnmanagedType.U4)]
                int lcid,
                out string categoryName);
        }
        
        [StructLayout(LayoutKind.Sequential)] //leftover(noAutoOffset)
        public sealed class tagSIZEL
        {
            public int cx = 0;
            public int cy = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)] //leftover(noAutoOffset)
        public sealed class tagOLEVERB
        {
            public int lVerb = 0;
            
            [MarshalAs(UnmanagedType.LPWStr)] // leftover(offset=4, customMarshal="UniStringMarshaller", lpszVerbName)
            public string lpszVerbName = null;
            
            [MarshalAs(UnmanagedType.U4)] // leftover(offset=8, fuFlags)
            public int fuFlags = 0;
            
            [MarshalAs(UnmanagedType.U4)] // leftover(offset=12, grfAttribs)
            public int grfAttribs = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)] // leftover(noAutoOffset)
        public sealed class tagLOGPALETTE
        {
            [MarshalAs(UnmanagedType.U2)] // leftover(offset=0, palVersion)
            public short palVersion = 0;
            
            [MarshalAs(UnmanagedType.U2)] // leftover(offset=2, palNumEntries)
            public short palNumEntries = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)] // leftover(noAutoOffset)
        public sealed class tagCONTROLINFO
        {
            [MarshalAs(UnmanagedType.U4)] // leftover(offset=0, cb)
            public int cb = Marshal.SizeOf(typeof(tagCONTROLINFO));
            
            public IntPtr hAccel = IntPtr.Zero;
            
            [MarshalAs(UnmanagedType.U2)] // leftover(offset=8, cAccel)
            public short cAccel = 0;
            
            [MarshalAs(UnmanagedType.U4)] //leftover(offset=10, dwFlags)
            public int dwFlags = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)] // leftover(noAutoOffset)
        public sealed class CA_STRUCT
        {
            public int cElems = 0;
            public IntPtr pElems = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public sealed class VARIANT {
            [MarshalAs(UnmanagedType.I2)]
            public short vt = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short reserved1 = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short reserved2 = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short reserved3 = 0;
            
            public IntPtr data1 = IntPtr.Zero;
            
            public IntPtr data2 = IntPtr.Zero;


            public bool Byref{
                get{
                    return 0 != (vt & (int)tagVT.VT_BYREF);
                }
            }

            public void Clear() {
                if ((this.vt == (int)tagVT.VT_UNKNOWN || this.vt == (int)tagVT.VT_DISPATCH) && this.data1 != IntPtr.Zero) {
                    Marshal.Release(this.data1);
                }

                if (this.vt == (int)tagVT.VT_BSTR && this.data1 != IntPtr.Zero) {
                    SysFreeString(this.data1);
                }

                this.data1 = this.data2 = IntPtr.Zero;
                this.vt = (int)tagVT.VT_EMPTY;
            }

            ~VARIANT() {
                Clear();
            }

            public static VARIANT FromObject(Object var) {
                VARIANT v = new VARIANT();

                if (var == null) {
                    v.vt = (int)tagVT.VT_EMPTY;
                }
                else if (Convert.IsDBNull(var)) {
                }
                else {
                    Type t = var.GetType();

                    if (t == typeof(bool)) {
                        v.vt = (int)tagVT.VT_BOOL;
                    }
                    else if (t == typeof(byte)) {
                        v.vt = (int)tagVT.VT_UI1;
                        v.data1 = (IntPtr)Convert.ToByte(var);
                    }
                    else if (t == typeof(char)) {
                        v.vt = (int)tagVT.VT_UI2;
                        v.data1 = (IntPtr)Convert.ToChar(var);
                    }
                    else if (t == typeof(string)) {
                        v.vt = (int)tagVT.VT_BSTR;
                        v.data1 = SysAllocString(Convert.ToString(var));
                    }
                    else if (t == typeof(short)) {
                        v.vt = (int)tagVT.VT_I2;
                        v.data1 = (IntPtr)Convert.ToInt16(var);
                    }
                    else if (t == typeof(int)) {
                        v.vt = (int)tagVT.VT_I4;
                        v.data1 = (IntPtr)Convert.ToInt32(var);
                    }
                    else if (t == typeof(long)) {
                        v.vt = (int)tagVT.VT_I8;
                        v.SetLong(Convert.ToInt64(var));
                    }
                    else if (t == typeof(Decimal)) {
                        v.vt = (int)tagVT.VT_CY;
                        Decimal c = (Decimal)var;
                        // Microsoft, it's bizzare that we need to call this as a static!
                        v.SetLong(Decimal.ToInt64(c));
                    }
                    else if (t == typeof(decimal)) {
                        v.vt = (int)tagVT.VT_DECIMAL;
                        Decimal d = Convert.ToDecimal(var);
                        v.SetLong(Decimal.ToInt64(d));
                    }
                    else if (t == typeof(double)) {
                        v.vt = (int)tagVT.VT_R8;
                        // how do we handle double?
                    }
                    else if (t == typeof(float) || t == typeof(Single)) {
                        v.vt = (int)tagVT.VT_R4;
                        // how do we handle float?
                    }
                    else if (t == typeof(DateTime)) {
                        v.vt = (int)tagVT.VT_DATE;
                        v.SetLong(Convert.ToDateTime(var).ToFileTime());
                    }
                    else if (t == typeof(SByte)) {
                        v.vt = (int)tagVT.VT_I1;
                        v.data1 = (IntPtr)Convert.ToSByte(var);
                    }
                    else if (t == typeof(UInt16)) {
                        v.vt = (int)tagVT.VT_UI2;
                        v.data1 = (IntPtr)Convert.ToUInt16(var);
                    }
                    else if (t == typeof(UInt32)) {
                        v.vt = (int)tagVT.VT_UI4;
                        v.data1 = (IntPtr)Convert.ToUInt32(var);
                    }
                    else if (t == typeof(UInt64)) {
                        v.vt = (int)tagVT.VT_UI8;
                        v.SetLong((long)Convert.ToUInt64(var));
                    }
                    else if (t == typeof(object) || t == typeof(UnsafeNativeMethods.IDispatch) || t.IsCOMObject) {
                        v.vt = (t == typeof(UnsafeNativeMethods.IDispatch) ? (short)tagVT.VT_DISPATCH : (short)tagVT.VT_UNKNOWN);
                        v.data1 = Marshal.GetIUnknownForObject(var);
                    }
                    else {
                        throw new ArgumentException("SR.GetString(SR.ConnPointUnhandledType, t.Name)");
                    }
                }
                return v;
            }

            [DllImport(ExternDll.Oleaut32,CharSet=CharSet.Auto)]
            private static extern IntPtr SysAllocString([In, MarshalAs(UnmanagedType.LPWStr)]string s);

            [DllImport(ExternDll.Oleaut32,CharSet=CharSet.Auto)]
            private static extern void SysFreeString(IntPtr pbstr);

            public void SetLong(long lVal) {
                data1 = (IntPtr)(lVal & 0xFFFFFFFF);
                data2 = (IntPtr)((lVal >> 32) & 0xFFFFFFFF);
            }

            public IntPtr ToCoTaskMemPtr() {
                IntPtr mem = Marshal.AllocCoTaskMem(16);
                Marshal.WriteInt16(mem, vt);
                Marshal.WriteInt16(mem, 2, reserved1);
                Marshal.WriteInt16(mem, 4, reserved2);
                Marshal.WriteInt16(mem, 6, reserved3);
                Marshal.WriteInt32(mem, 8, (int) data1);
                Marshal.WriteInt32(mem, 12, (int) data2);
                return mem;
            }

            public object ToObject() {
                IntPtr val = data1;
                long longVal;

                int vtType = (int)(this.vt & (short)tagVT.VT_TYPEMASK);

                switch (vtType) {
                case (int)tagVT.VT_EMPTY:
                    return null;
                case (int)tagVT.VT_NULL:
                    return Convert.DBNull;

                case (int)tagVT.VT_I1:
                    if (Byref) {
                        val = (IntPtr) Marshal.ReadByte(val);
                    }
                    return (SByte) (0xFF & (SByte) val);

                case (int)tagVT.VT_UI1:
                    if (Byref) {
                        val = (IntPtr) Marshal.ReadByte(val);
                    }

                    return (byte) (0xFF & (byte) val);

                case (int)tagVT.VT_I2:
                    if (Byref) {
                        val = (IntPtr) Marshal.ReadInt16(val);
                    }
                    return (short)(0xFFFF & (short) val);

                case (int)tagVT.VT_UI2:
                    if (Byref) {
                        val = (IntPtr) Marshal.ReadInt16(val);
                    }
                    return (UInt16)(0xFFFF & (UInt16) val);

                case (int)tagVT.VT_I4:
                case (int)tagVT.VT_INT:
                    if (Byref) {
                        val = (IntPtr) Marshal.ReadInt32(val);
                    }
                    return (int)val;

                case (int)tagVT.VT_UI4:
                case (int)tagVT.VT_UINT:
                    if (Byref) {
                        val = (IntPtr) Marshal.ReadInt32(val);
                    }
                    return (UInt32)val;

                case (int)tagVT.VT_I8:
                case (int)tagVT.VT_UI8:
                    if (Byref) {
                        longVal = Marshal.ReadInt64(val);
                    }
                    else {
                        longVal = ((uint)data1 & 0xffffffff) | ((uint)data2 << 32);
                    }

                    if (vt == (int)tagVT.VT_I8) {
                        return (long)longVal;
                    }
                    else {
                        return (UInt64)longVal;
                    }
                }

                if (Byref) {
                    val = GetRefInt(val);
                }

                switch (vtType) {
                case (int)tagVT.VT_R4:
                case (int)tagVT.VT_R8:

                    // can I use unsafe here?
                    throw new FormatException("SR.GetString(SR.CannotConvertIntToFloat)");

                case (int)tagVT.VT_CY:
                    // internally currency is 8-byte int scaled by 10,000
                    longVal = ((uint)data1 & 0xffffffff) | ((uint)data2 << 32);
                    return new Decimal(longVal);
                case (int)tagVT.VT_DATE:
                    throw new FormatException("SR.GetString(SR.CannotConvertDoubleToDate)");

                case (int)tagVT.VT_BSTR:
                case (int)tagVT.VT_LPWSTR:
                    return Marshal.PtrToStringUni(val);

                case (int)tagVT.VT_LPSTR:
                    return Marshal.PtrToStringAnsi(val);

                case (int)tagVT.VT_DISPATCH:
                case (int)tagVT.VT_UNKNOWN:
                    {
                        return Marshal.GetObjectForIUnknown(val);
                    }

                case (int)tagVT.VT_HRESULT:
                    return val;

                case (int)tagVT.VT_DECIMAL:
                    longVal = ((uint)data1 & 0xffffffff) | ((uint)data2 << 32);
                    return new Decimal(longVal);

                case (int)tagVT.VT_BOOL:
                    return (val != IntPtr.Zero);

                case (int)tagVT.VT_VARIANT:
                    VARIANT varStruct = (VARIANT)UnsafeNativeMethods.PtrToStructure(val, typeof(VARIANT));
                    return varStruct.ToObject();
                case (int)tagVT.VT_CLSID:
                    //Debug.Fail("PtrToStructure will not work with System.Guid...");
                    Guid guid =(Guid)UnsafeNativeMethods.PtrToStructure(val, typeof(Guid));
                    return guid;

                case (int)tagVT.VT_FILETIME:
                    longVal = ((uint)data1 & 0xffffffff) | ((uint)data2 << 32);
                    return new DateTime(longVal);

                case (int)tagVT.VT_USERDEFINED:
                    throw new ArgumentException("SR.GetString(SR.COM2UnhandledVT, \"VT_USERDEFINED\")");

                case (int)tagVT.VT_ARRAY:
                    //gSAFEARRAY sa = (tagSAFEARRAY)Marshal.PtrToStructure(val), typeof(tagSAFEARRAY));
                    //return GetArrayFromSafeArray(sa);

                case (int)tagVT.VT_VOID:
                case (int)tagVT.VT_PTR:
                case (int)tagVT.VT_SAFEARRAY:
                case (int)tagVT.VT_CARRAY:

                case (int)tagVT.VT_RECORD:
                case (int)tagVT.VT_BLOB:
                case (int)tagVT.VT_STREAM:
                case (int)tagVT.VT_STORAGE:
                case (int)tagVT.VT_STREAMED_OBJECT:
                case (int)tagVT.VT_STORED_OBJECT:
                case (int)tagVT.VT_BLOB_OBJECT:
                case (int)tagVT.VT_CF:
                case (int)tagVT.VT_BSTR_BLOB:
                case (int)tagVT.VT_VECTOR:
                case (int)tagVT.VT_BYREF:
                    //case (int)tagVT.VT_RESERVED:
                default:
                    int iVt = this.vt;
                    throw new ArgumentException("SR.GetString(SR.COM2UnhandledVT, iVt.ToString())");
                }
            }

            private static IntPtr GetRefInt(IntPtr value) {
                return Marshal.ReadIntPtr(value);
            }
        }
        
        [StructLayout(LayoutKind.Sequential)] // leftover(noAutoOffset)
        public sealed class tagLICINFO
        {
          [MarshalAs(UnmanagedType.U4)] // leftover(offset=0, cb)
          public int cbLicInfo = Marshal.SizeOf(typeof(tagLICINFO));
          
          public int fRuntimeAvailable = 0;
          public int fLicVerified = 0;
        }
        
        public enum  tagVT {
            VT_EMPTY = 0,
            VT_NULL = 1,
            VT_I2 = 2,
            VT_I4 = 3,
            VT_R4 = 4,
            VT_R8 = 5,
            VT_CY = 6,
            VT_DATE = 7,
            VT_BSTR = 8,
            VT_DISPATCH = 9,
            VT_ERROR = 10,
            VT_BOOL = 11,
            VT_VARIANT = 12,
            VT_UNKNOWN = 13,
            VT_DECIMAL = 14,
            VT_I1 = 16,
            VT_UI1 = 17,
            VT_UI2 = 18,
            VT_UI4 = 19,
            VT_I8 = 20,
            VT_UI8 = 21,
            VT_INT = 22,
            VT_UINT = 23,
            VT_VOID = 24,
            VT_HRESULT = 25,
            VT_PTR = 26,
            VT_SAFEARRAY = 27,
            VT_CARRAY = 28,
            VT_USERDEFINED = 29,
            VT_LPSTR = 30,
            VT_LPWSTR = 31,
            VT_RECORD = 36,
            VT_FILETIME = 64,
            VT_BLOB = 65,
            VT_STREAM = 66,
            VT_STORAGE = 67,
            VT_STREAMED_OBJECT = 68,
            VT_STORED_OBJECT = 69,
            VT_BLOB_OBJECT = 70,
            VT_CF = 71,
            VT_CLSID = 72,
            VT_BSTR_BLOB = 4095,
            VT_VECTOR = 4096,
            VT_ARRAY = 8192,
            VT_BYREF = 16384,
            VT_RESERVED = 32768,
            VT_ILLEGAL = 65535,
            VT_ILLEGALMASKED = 4095,
            VT_TYPEMASK = 4095
        }
        
        public delegate void TimerProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class WNDCLASS_D {
            public int      style = 0;
            public WndProc  lpfnWndProc = null;
            public int      cbClsExtra = 0;
            public int      cbWndExtra = 0;
            public IntPtr   hInstance = IntPtr.Zero;
            public IntPtr   hIcon = IntPtr.Zero;
            public IntPtr   hCursor = IntPtr.Zero;
            public IntPtr   hbrBackground = IntPtr.Zero;
            public string   lpszMenuName = null;
            public string   lpszClassName = null;
        }
        public delegate void TimerProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]        
        public class WNDCLASSEX_D {
            public int      cbSize = 0;
            public int      style = 0;
            public WndProc  lpfnWndProc = null;
            public int      cbClsExtra = 0;
            public int      cbWndExtra = 0;
            public IntPtr   hInstance = IntPtr.Zero;
            public IntPtr   hIcon = IntPtr.Zero;
            public IntPtr   hCursor = IntPtr.Zero;
            public IntPtr   hbrBackground = IntPtr.Zero;
            public string   lpszMenuName = null;
            public string   lpszClassName = null;
            public IntPtr   hIconSm = IntPtr.Zero;
        }

        public class MSOCM {
            // MSO Component registration flags
            public const int msocrfNeedIdleTime         = 1;
            public const int msocrfNeedPeriodicIdleTime = 2;
            public const int msocrfPreTranslateKeys     = 4;
            public const int msocrfPreTranslateAll      = 8;
            public const int msocrfNeedSpecActiveNotifs = 16;
            public const int msocrfNeedAllActiveNotifs  = 32;
            public const int msocrfExclusiveBorderSpace = 64;
            public const int msocrfExclusiveActivation = 128;
            public const int msocrfNeedAllMacEvents = 256;
            public const int msocrfMaster           = 512;
    
            // MSO Component registration advise flags (see msocstate enumeration)
            public const int msocadvfModal              = 1;
            public const int msocadvfRedrawOff          = 2;
            public const int msocadvfWarningsOff        = 4;
            public const int msocadvfRecording          = 8;
    
            // MSO Component Host flags
            public const int msochostfExclusiveBorderSpace = 1;
    
            // MSO idle flags, passed to IMsoComponent::FDoIdle and 
            // IMsoStdComponentMgr::FDoIdle.
            public const int msoidlefPeriodic    = 1;
            public const int msoidlefNonPeriodic = 2;
            public const int msoidlefPriority    = 4;
            public const int msoidlefAll         = -1;
    
            // MSO Reasons for pushing a message loop, passed to 
            // IMsoComponentManager::FPushMessageLoop and 
            // IMsoComponentHost::FPushMessageLoop.  The host should remain in message
            // loop until IMsoComponent::FContinueMessageLoop 
            public const int msoloopMain      = -1; // Note this is not an official MSO loop -- it just must be distinct.
            public const int msoloopFocusWait = 1;
            public const int msoloopDoEvents  = 2;
            public const int msoloopDebug     = 3;
            public const int msoloopModalForm = 4;
            public const int msoloopModalAlert = 5;
    
    
            // msocstate values: state IDs passed to 
            //    IMsoComponent::OnEnterState, 
            //    IMsoComponentManager::OnComponentEnterState/FOnComponentExitState/FInState,
            //    IMsoComponentHost::OnComponentEnterState,
            //    IMsoStdComponentMgr::OnHostEnterState/FOnHostExitState/FInState.
            //    When the host or a component is notified through one of these methods that 
            //    another entity (component or host) is entering or exiting a state 
            //    identified by one of these state IDs, the host/component should take
            //    appropriate action:
            //        msocstateModal (modal state):
            //            If app is entering modal state, host/component should disable
            //            its toplevel windows, and reenable them when app exits this
            //            state.  Also, when this state is entered or exited, host/component
            //            should notify approprate inplace objects via 
            //            IOleInPlaceActiveObject::EnableModeless.
            //        msocstateRedrawOff (redrawOff state):
            //            If app is entering redrawOff state, host/component should disable
            //            repainting of its windows, and reenable repainting when app exits
            //            this state.
            //        msocstateWarningsOff (warningsOff state):
            //            If app is entering warningsOff state, host/component should disable
            //            the presentation of any user warnings, and reenable this when
            //            app exits this state.
            //        msocstateRecording (Recording state):
            //            Used to notify host/component when Recording is turned on or off.
            public const int msocstateModal       = 1;
            public const int msocstateRedrawOff   = 2;
            public const int msocstateWarningsOff = 3;
            public const int msocstateRecording   = 4;
    
    
            //             ** Comments on State Contexts **
            // IMsoComponentManager::FCreateSubComponentManager allows one to create a 
            // hierarchical tree of component managers.  This tree is used to maintain 
            // multiple contexts with regard to msocstateXXX states.  These contexts are 
            // referred to as 'state contexts'.
            // Each component manager in the tree defines a state context.  The
            // components registered with a particular component manager or any of its
            // descendents live within that component manager's state context.  Calls
            // to IMsoComponentManager::OnComponentEnterState/FOnComponentExitState
            // can be used to  affect all components, only components within the component
            // manager's state context, or only those components that are outside of the
            // component manager's state context.  IMsoComponentManager::FInState is used
            // to query the state of the component manager's state context at its root.
            // 
            // msoccontext values: context indicators passed to 
            // IMsoComponentManager::OnComponentEnterState/FOnComponentExitState.
            // These values indicate the state context that is to be affected by the
            // state change. 
            // In IMsoComponentManager::OnComponentEnterState/FOnComponentExitState,
            // the comp mgr informs only those components/host that are within the
            // specified state context.
            public const int msoccontextAll    = 0;
            public const int msoccontextMine   = 1;
            public const int msoccontextOthers = 2; 
    
            //     ** WM_MOUSEACTIVATE Note (for top level compoenents and host) **
            // If the active (or tracking) comp's reg info indicates that it
            // wants mouse messages, then no MA_xxxANDEAT value should be returned 
            // from WM_MOUSEACTIVATE, so that the active (or tracking) comp will be able
            // to process the resulting mouse message.  If one does not want to examine
            // the reg info, no MA_xxxANDEAT value should be returned from 
            // WM_MOUSEACTIVATE if any comp is active (or tracking).
            // One can query the reg info of the active (or tracking) component at any
            // time via IMsoComponentManager::FGetActiveComponent.
    
            // msogac values: values passed to 
            // IMsoComponentManager::FGetActiveComponent.
            public const int msogacActive    = 0;
            public const int msogacTracking   = 1;
            public const int msogacTrackingOrActive = 2; 
    
            // msocWindow values: values passed to IMsoComponent::HwndGetWindow.
            public const int msocWindowFrameToplevel = 0;
            public const int msocWindowFrameOwner = 1;
            public const int msocWindowComponent = 2;
            public const int msocWindowDlgOwner = 3;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class TOOLINFO_T
        {
            public int      cbSize = Marshal.SizeOf(typeof(TOOLINFO_T));
            public int      uFlags = 0;
            public IntPtr   hwnd = IntPtr.Zero;
            public IntPtr   uId = IntPtr.Zero;
            public RECT     rect = new RECT();
            public IntPtr   hinst = IntPtr.Zero;
            public string   lpszText = null;
            public IntPtr   lParam = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagDVTARGETDEVICE {
            [MarshalAs(UnmanagedType.U4)]
            public   int tdSize = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short tdDriverNameOffset = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short tdDeviceNameOffset = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short tdPortNameOffset = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short tdExtDevmodeOffset = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public struct TV_ITEM {
            public int      mask;
            public IntPtr   hItem;
            public int      state;
            public int      stateMask;
            public IntPtr pszText; // LPTSTR
            public int      cchTextMax;
            public int      iImage;
            public int      iSelectedImage;
            public int      cChildren;
            public IntPtr   lParam;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public struct TV_INSERTSTRUCT {
            public IntPtr   hParent;
            public IntPtr   hInsertAfter;
            public int      item_mask;
            public int      item_hItem;
            public int      item_state;
            public int      item_stateMask;
            public IntPtr item_pszText; // LPTSTR
            public int      item_cchTextMax;
            public int      item_iImage;
            public int      item_iSelectedImage;
            public int      item_cChildren;
            public IntPtr   item_lParam;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct NMTREEVIEW
        {
            public NMHDR    nmhdr;
            public int      action;
            public TV_ITEM  itemOld;
            public TV_ITEM  itemNew;
            public int      ptDrag_X; // This should be declared as POINT
            public int      ptDrag_Y; // we use unsafe blocks to manipulate 
                                      // NMTREEVIEW quickly, and POINT is declared
                                      // as a class.  Too much churn to change POINT
                                      // now.
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class NMTVDISPINFO
        {
            public NMHDR    hdr = new NMHDR();
            public TV_ITEM  item = new TV_ITEM();
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public sealed class POINTL {
            public   int x = 0;
            public   int y = 0;
        }
    
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct HIGHCONTRAST {
            public int cbSize;
            public int dwFlags;
            public string lpszDefaultScheme;
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct HIGHCONTRAST_I {
            public int cbSize;
            public int dwFlags;
            public IntPtr lpszDefaultScheme;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class TCITEM_T
        {
            public int      mask = 0;
            public int      dwState = 0;
            public int      dwStateMask = 0;
            public string   pszText = null;
            public int      cchTextMax = 0;
            public int      iImage = 0;
            public IntPtr   lParam = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public sealed class STATDATA {
            [MarshalAs(UnmanagedType.U4)]
            public   int advf = 0;
            [MarshalAs(UnmanagedType.U4)]
            public   int dwConnection = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)] // leftover(noAutoOffset)
        public sealed class tagDISPPARAMS
        {
          public IntPtr rgvarg = IntPtr.Zero;
          public IntPtr rgdispidNamedArgs = IntPtr.Zero;
          [MarshalAs(UnmanagedType.U4)] // leftover(offset=8, cArgs)
          public int cArgs = 0;
          [MarshalAs(UnmanagedType.U4)] // leftover(offset=12, cNamedArgs)
          public int cNamedArgs = 0;
        }
        
        public enum  tagINVOKEKIND {
            INVOKE_FUNC = 1,
            INVOKE_PROPERTYGET = 2,
            INVOKE_PROPERTYPUT = 4,
            INVOKE_PROPERTYPUTREF = 8
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class tagEXCEPINFO {
            [MarshalAs(UnmanagedType.U2)]
            public short wCode = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short wReserved = 0;
            [MarshalAs(UnmanagedType.BStr)]
            public string bstrSource = null;
            [MarshalAs(UnmanagedType.BStr)]
            public string bstrDescription = null;
            [MarshalAs(UnmanagedType.BStr)]
            public string bstrHelpFile = null;
            [MarshalAs(UnmanagedType.U4)]
            public int dwHelpContext = 0;
            
            public IntPtr pvReserved = IntPtr.Zero;
            
            public IntPtr pfnDeferredFillIn = IntPtr.Zero;
            [MarshalAs(UnmanagedType.U4)]
            public int scode = 0;
        }
        
        public enum  tagDESCKIND {
            DESCKIND_NONE = 0,
            DESCKIND_FUNCDESC = 1,
            DESCKIND_VARDESC = 2,
            DESCKIND_TYPECOMP = 3,
            DESCKIND_IMPLICITAPPOBJ = 4,
            DESCKIND_MAX = 5
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagFUNCDESC {
            public   int memid = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short lprgscode = 0;

            // This is marked as NATIVE_TYPE_PTR,
            // but the EE doesn't look for that, tries to handle it as
            // a ELEMENT_TYPE_VALUECLASS and fails because it
            // isn't a NATIVE_TYPE_NESTEDSTRUCT
            //[MarshalAs(UnmanagedType.PTR)]
            
            public IntPtr lprgelemdescParam = IntPtr.Zero; // NativeMethods.tagELEMDESC

            // cpb, Microsoft, the EE chokes on Enums in structs
           
            public int funckind = 0; // NativeMethods.tagFUNCKIND
            public int invkind = 0; // NativeMethods.tagINVOKEKIND
            public int callconv = 0; // NativeMethods.tagCALLCONV

            [MarshalAs(UnmanagedType.I2)]
            public   short cParams = 0;
            [MarshalAs(UnmanagedType.I2)]
            public   short cParamsOpt = 0;
            [MarshalAs(UnmanagedType.I2)]
            public   short oVft = 0;
            [MarshalAs(UnmanagedType.I2)]
            public   short cScodes = 0;
            public   NativeMethods.value_tagELEMDESC elemdescFunc = new NativeMethods.value_tagELEMDESC();
            [MarshalAs(UnmanagedType.U2)]
            public   short wFuncFlags = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagVARDESC {
            public   int memid = 0;
            public   IntPtr lpstrSchema = IntPtr.Zero;
            public   IntPtr unionMember = IntPtr.Zero;
            public   NativeMethods.value_tagELEMDESC elemdescVar = new NativeMethods.value_tagELEMDESC();
            [MarshalAs(UnmanagedType.U2)]
            public   short wVarFlags = 0;
            public   int varkind = 0; // NativeMethods.tagVARKIND
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct  value_tagELEMDESC {
            public    NativeMethods.tagTYPEDESC tdesc;
            public    NativeMethods.tagPARAMDESC paramdesc;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int flags;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class DRAWITEMSTRUCT {
            public int CtlType = 0;
            public int CtlID = 0;
            public int itemID = 0;
            public int itemAction = 0;
            public int itemState = 0;
            public IntPtr hwndItem = IntPtr.Zero;
            public IntPtr hDC = IntPtr.Zero;
            public RECT   rcItem = new RECT();
            public IntPtr itemData = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class MEASUREITEMSTRUCT {
            public int CtlType = 0;
            public int CtlID = 0;
            public int itemID = 0;
            public int itemWidth = 0;
            public int itemHeight = 0;
            public IntPtr itemData = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class HELPINFO {
            public int      cbSize = Marshal.SizeOf(typeof(HELPINFO));
            public int      iContextType = 0;
            public int      iCtrlId = 0;
            public IntPtr   hItemHandle = IntPtr.Zero;
            public int      dwContextId = 0;
            public POINT    MousePos = new POINT();
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public class ACCEL {
            public byte fVirt = 0;
            public short key = 0;
            public short cmd = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class MINMAXINFO {
            public POINT    ptReserved = new POINT();
            public POINT    ptMaxSize = new POINT();
            public POINT    ptMaxPosition = new POINT();
            public POINT    ptMinTrackSize = new POINT();
            public POINT    ptMaxTrackSize = new POINT();
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class CREATESTRUCT {
            public IntPtr lpCreateParams = IntPtr.Zero;
            public IntPtr hInstance = IntPtr.Zero;
            public IntPtr hMenu = IntPtr.Zero;
            public IntPtr hwndParent = IntPtr.Zero;
            public int cy = 0;
            public int cx = 0;
            public int y = 0;
            public int x = 0;
            public int style = 0;
            public string lpszName = null;
            public string lpszClass = null;
            public int dwExStyle = 0;
        }
    
        [ComImport(), Guid("B196B28B-BAB4-101A-B69C-00AA00341D07"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ISpecifyPropertyPages {
             void GetPages(
                [Out] 
                NativeMethods.tagCAUUID pPages);

        }
        
        [StructLayout(LayoutKind.Sequential)] // leftover(noAutoOffset)
        public sealed class tagCAUUID
        {
            [MarshalAs(UnmanagedType.U4)] // leftover(offset=0, cElems)
            public int cElems = 0;
            public IntPtr pElems = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct NMTOOLBAR
        {
            public NMHDR    hdr;
            public int      iItem;
            public TBBUTTON tbButton;
            public int      cchText;
            public IntPtr   pszText;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct TBBUTTON {
            public int      iBitmap;
            public int      idCommand;
            public byte     fsState;
            public byte     fsStyle;
            public byte     bReserved0;
            public byte     bReserved1;
            public int      dwData;
            public int      iString;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class TOOLTIPTEXT
        {
            public NMHDR  hdr = new NMHDR();
            public IntPtr lpszText = IntPtr.Zero;
            
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=80)]
            public string szText = null;
            
            public IntPtr hinst = IntPtr.Zero;
            public int    uFlags = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
        public class TOOLTIPTEXTA
        {
            public NMHDR  hdr = new NMHDR();
            public IntPtr lpszText = IntPtr.Zero;
            
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=80)]
            public string szText = null;
            
            public IntPtr hinst = IntPtr.Zero;
            public int    uFlags = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct TBBUTTONINFO
        {
            public int      cbSize;
            public int      dwMask;
            public int      idCommand;
            public int      iImage;
            public byte     fsState;
            public byte     fsStyle;
            public short    cx;
            public IntPtr   lParam;
            public IntPtr   pszText;
            public int      cchTest;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public class TV_HITTESTINFO {
            public int      pt_x = 0;
            public int      pt_y = 0;
            public int      flags = 0;
            public IntPtr   hItem = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class NMTVCUSTOMDRAW
        {
            public NMCUSTOMDRAW    nmcd = new NMCUSTOMDRAW();
            public int clrText = 0;
            public int clrTextBk = 0;
            public int iLevel = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct NMCUSTOMDRAW {
            public NMHDR    nmcd;
            public int      dwDrawStage;
            public IntPtr   hdc;
            public RECT     rc;
            public int      dwItemSpec;
            public int      uItemState;
            public IntPtr   lItemlParam;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public class MCHITTESTINFO {
            public int      cbSize = Marshal.SizeOf(typeof(MCHITTESTINFO));
            public int      pt_x = 0;
            public int      pt_y = 0;
            public int      uHit = 0;
            public short st_wYear = 0;
            public short st_wMonth = 0;
            public short st_wDayOfWeek = 0;
            public short st_wDay = 0;
            public short st_wHour = 0;
            public short st_wMinute = 0;
            public short st_wSecond = 0;
            public short st_wMilliseconds = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class NMSELCHANGE
        {
            public NMHDR        nmhdr = new NMHDR();
            public SYSTEMTIME   stSelStart = null;
            public SYSTEMTIME   stSelEnd = null;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class NMDAYSTATE
        {
            public NMHDR        nmhdr = new NMHDR();
            public SYSTEMTIME   stStart = null;
            public int          cDayState = 0;
            public IntPtr       prgDayState = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct NMLVCUSTOMDRAW
        {
            public NMCUSTOMDRAW    nmcd;
            public int clrText;
            public int clrTextBk;
            public int iSubItem;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class NMLVKEYDOWN
        {
            public NMHDR hdr = new NMHDR();
            public short wVKey = 0;
            public uint flags = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public class LVHITTESTINFO {
            public int      pt_x = 0;
            public int      pt_y = 0;
            public int      flags = 0;
            public int      iItem = 0;
            public int      iSubItem = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public class LVCOLUMN_T
        {
            public int      mask = 0;
            public int      fmt = 0;
            public int      cx = 0;
            public string   pszText = null;
            public int      cchTextMax = 0;
            public int      iSubItem = 0;
            public int      iImage = 0;
            public int      iOrder = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public struct LVFINDINFO {
            public int      flags;
            public string   psz;
            public IntPtr   lParam;
            public int      ptX; // was POINT pt
            public int      ptY;
            public int      vkDirection;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public struct LVITEM {
            public int      mask;
            public int      iItem;
            public int      iSubItem;
            public int      state;
            public int      stateMask;
            public string   pszText;
            public int      cchTextMax;
            public int      iImage;
            public IntPtr   lParam;
            public int      iIndent;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public struct LVITEM_NOTEXT {
            public int      mask;
            public int      iItem;
            public int      iSubItem;
            public int      state;
            public int      stateMask;
            public IntPtr pszText; // string
            public int      cchTextMax;
            public int      iImage;
            public IntPtr   lParam;
            public int      iIndent;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
        public class LVCOLUMN {
            public int      mask = 0;
            public int      fmt = 0;
            public int      cx = 0;
            public IntPtr pszText = IntPtr.Zero; // LPWSTR
            public int      cchTextMax = 0;
            public int      iSubItem = 0;
            public int      iImage = 0;
            public int      iOrder = 0;
        }
    
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class NMLVDISPINFO
        {
            public NMHDR  hdr = new NMHDR();
            public LVITEM item = new LVITEM();
        }
    
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class NMLVDISPINFO_NOTEXT
        {
            public NMHDR  hdr = new NMHDR();
            public LVITEM_NOTEXT item = new LVITEM_NOTEXT();
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public class CLIENTCREATESTRUCT {
            public IntPtr hWindowMenu = IntPtr.Zero;
            public int idFirstChild = 0;
        
            public CLIENTCREATESTRUCT(IntPtr hmenu, int idFirst) {
                hWindowMenu = hmenu;
                idFirstChild = idFirst;
            }
        }
    
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class NMDATETIMECHANGE
        {
            public NMHDR        nmhdr = new NMHDR();
            public int          dwFlags = 0;
            public SYSTEMTIME   st = null;
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class NMDATETIMEFORMAT
        {
            public NMHDR      nmhdr = new NMHDR();
            public string     pszFormat = null;
            public SYSTEMTIME st = null;
            public string     pszDisplay = null;
    
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
            public string     szDisplay = null;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class NMDATETIMEFORMATQUERY
        {
            public NMHDR  nmhdr = new NMHDR();
            public string pszFormat = null;
            public SIZE   szMax = new SIZE();
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class NMDATETIMEWMKEYDOWN
        {
            public NMHDR      nmhdr = new NMHDR();
            public int        nVirtKey = 0;
            public string     pszFormat = null;
            public SYSTEMTIME st = null;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class COPYDATASTRUCT {
            public int dwData = 0;
            public int cbData = 0;
            public IntPtr lpData = IntPtr.Zero;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class NMHEADER {
            public IntPtr hwndFrom = IntPtr.Zero; 
            public int idFrom = 0; 
            public int code = 0; 
            public int iItem = 0;
            public int iButton = 0;
            public IntPtr pItem = IntPtr.Zero;  // HDITEM*
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class MOUSEHOOKSTRUCT {
            // pt was a by-value POINT structure
            public int      pt_x = 0;
            public int      pt_y = 0;
            public IntPtr   hWnd = IntPtr.Zero;
            public int      wHitTestCode = 0;
            public int      dwExtraInfo = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class CHARRANGE
        {
            public int  cpMin = 0;
            public int  cpMax = 0;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=4)]
        public class CHARFORMATW
        {
            public int      cbSize = Marshal.SizeOf(typeof(CHARFORMATW));
            public int      dwMask = 0;
            public int      dwEffects = 0;
            public int      yHeight = 0;
            public int      yOffset = 0;
            public int      crTextColor = 0;
            public byte     bCharSet = 0;
            public byte     bPitchAndFamily = 0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=64)]
            public byte[]   szFaceName = new byte[64];
        }
        
        [StructLayout(LayoutKind.Sequential, Pack=4)]
        public class CHARFORMATA
        {
            public int      cbSize = Marshal.SizeOf(typeof(CHARFORMATA));
            public int      dwMask = 0;
            public int      dwEffects = 0;
            public int      yHeight = 0;
            public int      yOffset = 0;
            public int      crTextColor = 0;
            public byte     bCharSet = 0;
            public byte     bPitchAndFamily = 0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
            public byte[]   szFaceName = new byte[32];
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class TEXTRANGE
        {
            public CHARRANGE    chrg = null;
            public IntPtr       lpstrText = IntPtr.Zero; // allocated by caller, zero terminated by RichEdit
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi, Pack=4)]
        public class SELCHANGE {
            public NMHDR nmhdr = new NMHDR();
            public CHARRANGE chrg = null;
            public int seltyp = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class PARAFORMAT
        {
            public int      cbSize = Marshal.SizeOf(typeof(PARAFORMAT));
            public int      dwMask = 0;
            public short    wNumbering = 0;
            public short    wReserved = 0;
            public int      dxStartIndent = 0;
            public int      dxRightIndent = 0;
            public int      dxOffset = 0;
            public short    wAlignment = 0;
            public short    cTabCount = 0;
    
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
            public int[]    rgxTabs = null;
        }
    
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class FINDTEXT
        {
            public CHARRANGE    chrg = null;
            public string       lpstrText = null;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class REPASTESPECIAL
        {
            public int  dwAspect = 0;
            public int  dwParam = 0;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class ENLINK
        {
            public NMHDR    nmhdr = new NMHDR();
            public int      msg = 0;
            public IntPtr   wParam = IntPtr.Zero;
            public IntPtr   lParam = IntPtr.Zero;
            public CHARRANGE charrange = null;
        }
    
        public abstract class CharBuffer {
    
            public static CharBuffer CreateBuffer(int size) {
                if (Marshal.SystemDefaultCharSize == 1) {
                    return new AnsiCharBuffer(size);
                }
                return new UnicodeCharBuffer(size);
            }
    
            public abstract IntPtr AllocCoTaskMem();
            public abstract string GetString();
            public abstract void PutCoTaskMem(IntPtr ptr);
            public abstract void PutString(string s);
        }
    
        public class AnsiCharBuffer : CharBuffer {
    
            internal byte[] buffer;
            internal int offset;
    
            public AnsiCharBuffer(int size) {
                buffer = new byte[size];
            }
    
            public override IntPtr AllocCoTaskMem() {
                IntPtr result = Marshal.AllocCoTaskMem(buffer.Length);
                Marshal.Copy(buffer, 0, result, buffer.Length);
                return result;
            }
    
            public override string GetString() {
                int i = offset;
                while (i < buffer.Length && buffer[i] != 0)
                    i++;
                string result = Encoding.Default.GetString(buffer, offset, i - offset);
                if (i < buffer.Length)
                    i++;
                offset = i;
                return result;
            }
    
            public override void PutCoTaskMem(IntPtr ptr) {
                Marshal.Copy(ptr, buffer, 0, buffer.Length);
                offset = 0;
            }
    
            public override void PutString(string s) {
                byte[] bytes = Encoding.Default.GetBytes(s);
                int count = Math.Min(bytes.Length, buffer.Length - offset);
                Array.Copy(bytes, 0, buffer, offset, count);
                offset += count;
                if (offset < buffer.Length) buffer[offset++] = 0;
            }
        }
    
        public class UnicodeCharBuffer : CharBuffer {
    
            internal char[] buffer;
            internal int offset;
    
            public UnicodeCharBuffer(int size) {
                buffer = new char[size];
            }
    
            public override IntPtr AllocCoTaskMem() {
                IntPtr result = Marshal.AllocCoTaskMem(buffer.Length * 2);
                Marshal.Copy(buffer, 0, result, buffer.Length);
                return result;
            }
    
            public override String GetString() {
                int i = offset;
                while (i < buffer.Length && buffer[i] != 0) i++;
                string result = new string(buffer, offset, i - offset);
                if (i < buffer.Length) i++;
                offset = i;
                return result;
            }
    
            public override void PutCoTaskMem(IntPtr ptr) {
                Marshal.Copy(ptr, buffer, 0, buffer.Length);
                offset = 0;
            }
    
            public override void PutString(string s) {
                int count = Math.Min(s.Length, buffer.Length - offset);
                s.CopyTo(0, buffer, offset, count);
                offset += count;
                if (offset < buffer.Length) buffer[offset++] = (char)0;
            }
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class ENDROPFILES
        {
            public NMHDR    nmhdr = new NMHDR();
            public IntPtr   hDrop = IntPtr.Zero;
            public int      cp = 0;
            public bool     fProtected = false;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public class REQRESIZE
        {
            public NMHDR    nmhdr = new NMHDR();
            public RECT     rc = new RECT();
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class ENPROTECTED
        {
            public NMHDR    nmhdr = new NMHDR();
            public int      msg = 0;
            public IntPtr   wParam = IntPtr.Zero;
            public IntPtr   lParam = IntPtr.Zero;
            public CHARRANGE chrg = null;
        }
    
        public class ActiveX {
            public const   int OCM__BASE = 0x2000;
            public const   int DISPID_VALUE = unchecked((int)0x0);
            public const   int DISPID_UNKNOWN = unchecked((int)0xFFFFFFFF);
            public const   int DISPID_AUTOSIZE = unchecked((int)0xFFFFFE0C);
            public const   int DISPID_BACKCOLOR = unchecked((int)0xFFFFFE0B);
            public const   int DISPID_BACKSTYLE = unchecked((int)0xFFFFFE0A);
            public const   int DISPID_BORDERCOLOR = unchecked((int)0xFFFFFE09);
            public const   int DISPID_BORDERSTYLE = unchecked((int)0xFFFFFE08);
            public const   int DISPID_BORDERWIDTH = unchecked((int)0xFFFFFE07);
            public const   int DISPID_DRAWMODE = unchecked((int)0xFFFFFE05);
            public const   int DISPID_DRAWSTYLE = unchecked((int)0xFFFFFE04);
            public const   int DISPID_DRAWWIDTH = unchecked((int)0xFFFFFE03);
            public const   int DISPID_FILLCOLOR = unchecked((int)0xFFFFFE02);
            public const   int DISPID_FILLSTYLE = unchecked((int)0xFFFFFE01);
            public const   int DISPID_FONT = unchecked((int)0xFFFFFE00);
            public const   int DISPID_FORECOLOR = unchecked((int)0xFFFFFDFF);
            public const   int DISPID_ENABLED = unchecked((int)0xFFFFFDFE);
            public const   int DISPID_HWND = unchecked((int)0xFFFFFDFD);
            public const   int DISPID_TABSTOP = unchecked((int)0xFFFFFDFC);
            public const   int DISPID_TEXT = unchecked((int)0xFFFFFDFB);
            public const   int DISPID_CAPTION = unchecked((int)0xFFFFFDFA);
            public const   int DISPID_BORDERVISIBLE = unchecked((int)0xFFFFFDF9);
            public const   int DISPID_APPEARANCE = unchecked((int)0xFFFFFDF8);
            public const   int DISPID_MOUSEPOINTER = unchecked((int)0xFFFFFDF7);
            public const   int DISPID_MOUSEICON = unchecked((int)0xFFFFFDF6);
            public const   int DISPID_PICTURE = unchecked((int)0xFFFFFDF5);
            public const   int DISPID_VALID = unchecked((int)0xFFFFFDF4);
            public const   int DISPID_READYSTATE = unchecked((int)0xFFFFFDF3);
            public const   int DISPID_REFRESH = unchecked((int)0xFFFFFDDA);
            public const   int DISPID_DOCLICK = unchecked((int)0xFFFFFDD9);
            public const   int DISPID_ABOUTBOX = unchecked((int)0xFFFFFDD8);
            public const   int DISPID_CLICK = unchecked((int)0xFFFFFDA8);
            public const   int DISPID_DBLCLICK = unchecked((int)0xFFFFFDA7);
            public const   int DISPID_KEYDOWN = unchecked((int)0xFFFFFDA6);
            public const   int DISPID_KEYPRESS = unchecked((int)0xFFFFFDA5);
            public const   int DISPID_KEYUP = unchecked((int)0xFFFFFDA4);
            public const   int DISPID_MOUSEDOWN = unchecked((int)0xFFFFFDA3);
            public const   int DISPID_MOUSEMOVE = unchecked((int)0xFFFFFDA2);
            public const   int DISPID_MOUSEUP = unchecked((int)0xFFFFFDA1);
            public const   int DISPID_ERROREVENT = unchecked((int)0xFFFFFDA0);
            public const   int DISPID_RIGHTTOLEFT = unchecked((int)0xFFFFFD9D);
            public const   int DISPID_READYSTATECHANGE = unchecked((int)0xFFFFFD9F);
            public const   int DISPID_AMBIENT_BACKCOLOR = unchecked((int)0xFFFFFD43);
            public const   int DISPID_AMBIENT_DISPLAYNAME = unchecked((int)0xFFFFFD42);
            public const   int DISPID_AMBIENT_FONT = unchecked((int)0xFFFFFD41);
            public const   int DISPID_AMBIENT_FORECOLOR = unchecked((int)0xFFFFFD40);
            public const   int DISPID_AMBIENT_LOCALEID = unchecked((int)0xFFFFFD3F);
            public const   int DISPID_AMBIENT_MESSAGEREFLECT = unchecked((int)0xFFFFFD3E);
            public const   int DISPID_AMBIENT_SCALEUNITS = unchecked((int)0xFFFFFD3D);
            public const   int DISPID_AMBIENT_TEXTALIGN = unchecked((int)0xFFFFFD3C);
            public const   int DISPID_AMBIENT_USERMODE = unchecked((int)0xFFFFFD3B);
            public const   int DISPID_AMBIENT_UIDEAD = unchecked((int)0xFFFFFD3A);
            public const   int DISPID_AMBIENT_SHOWGRABHANDLES = unchecked((int)0xFFFFFD39);
            public const   int DISPID_AMBIENT_SHOWHATCHING = unchecked((int)0xFFFFFD38);
            public const   int DISPID_AMBIENT_DISPLAYASDEFAULT = unchecked((int)0xFFFFFD37);
            public const   int DISPID_AMBIENT_SUPPORTSMNEMONICS = unchecked((int)0xFFFFFD36);
            public const   int DISPID_AMBIENT_AUTOCLIP = unchecked((int)0xFFFFFD35);
            public const   int DISPID_AMBIENT_APPEARANCE = unchecked((int)0xFFFFFD34);
            public const   int DISPID_AMBIENT_PALETTE = unchecked((int)0xFFFFFD2A);
            public const   int DISPID_AMBIENT_TRANSFERPRIORITY = unchecked((int)0xFFFFFD28);
            public const   int DISPID_AMBIENT_RIGHTTOLEFT = unchecked((int)0xFFFFFD24);
            public const   int DISPID_Name = unchecked((int)0xFFFFFCE0);
            public const   int DISPID_Delete = unchecked((int)0xFFFFFCDF);
            public const   int DISPID_Object = unchecked((int)0xFFFFFCDE);
            public const   int DISPID_Parent = unchecked((int)0xFFFFFCDD);
            public const   int DVASPECT_CONTENT = 0x1;
            public const   int DVASPECT_THUMBNAIL = 0x2;
            public const   int DVASPECT_ICON = 0x4;
            public const   int DVASPECT_DOCPRINT = 0x8;
            public const   int OLEMISC_RECOMPOSEONRESIZE = 0x1;
            public const   int OLEMISC_ONLYICONIC = 0x2;
            public const   int OLEMISC_INSERTNOTREPLACE = 0x4;
            public const   int OLEMISC_STATIC = 0x8;
            public const   int OLEMISC_CANTLINKINSIDE = 0x10;
            public const   int OLEMISC_CANLINKBYOLE1 = 0x20;
            public const   int OLEMISC_ISLINKOBJECT = 0x40;
            public const   int OLEMISC_INSIDEOUT = 0x80;
            public const   int OLEMISC_ACTIVATEWHENVISIBLE = 0x100;
            public const   int OLEMISC_RENDERINGISDEVICEINDEPENDENT = 0x200;
            public const   int OLEMISC_INVISIBLEATRUNTIME = 0x400;
            public const   int OLEMISC_ALWAYSRUN = 0x800;
            public const   int OLEMISC_ACTSLIKEBUTTON = 0x1000;
            public const   int OLEMISC_ACTSLIKELABEL = 0x2000;
            public const   int OLEMISC_NOUIACTIVATE = 0x4000;
            public const   int OLEMISC_ALIGNABLE = 0x8000;
            public const   int OLEMISC_SIMPLEFRAME = 0x10000;
            public const   int OLEMISC_SETCLIENTSITEFIRST = 0x20000;
            public const   int OLEMISC_IMEMODE = 0x40000;
            public const   int OLEMISC_IGNOREACTIVATEWHENVISIBLE = 0x80000;
            public const   int OLEMISC_WANTSTOMENUMERGE = 0x100000;
            public const   int OLEMISC_SUPPORTSMULTILEVELUNDO = 0x200000;
            public const   int QACONTAINER_SHOWHATCHING = 0x1;
            public const   int QACONTAINER_SHOWGRABHANDLES = 0x2;
            public const   int QACONTAINER_USERMODE = 0x4;
            public const   int QACONTAINER_DISPLAYASDEFAULT = 0x8;
            public const   int QACONTAINER_UIDEAD = 0x10;
            public const   int QACONTAINER_AUTOCLIP = 0x20;
            public const   int QACONTAINER_MESSAGEREFLECT = 0x40;
            public const   int QACONTAINER_SUPPORTSMNEMONICS = 0x80;
            public const   int XFORMCOORDS_POSITION = 0x1;
            public const   int XFORMCOORDS_SIZE = 0x2;
            public const   int XFORMCOORDS_HIMETRICTOCONTAINER = 0x4;
            public const   int XFORMCOORDS_CONTAINERTOHIMETRIC = 0x8;
            public const   int PROPCAT_Nil = unchecked((int)0xFFFFFFFF);
            public const   int PROPCAT_Misc = unchecked((int)0xFFFFFFFE);
            public const   int PROPCAT_Font = unchecked((int)0xFFFFFFFD);
            public const   int PROPCAT_Position = unchecked((int)0xFFFFFFFC);
            public const   int PROPCAT_Appearance = unchecked((int)0xFFFFFFFB);
            public const   int PROPCAT_Behavior = unchecked((int)0xFFFFFFFA);
            public const   int PROPCAT_Data = unchecked((int)0xFFFFFFF9);
            public const   int PROPCAT_List = unchecked((int)0xFFFFFFF8);
            public const   int PROPCAT_Text = unchecked((int)0xFFFFFFF7);
            public const   int PROPCAT_Scale = unchecked((int)0xFFFFFFF6);
            public const   int PROPCAT_DDE = unchecked((int)0xFFFFFFF5);
            public const   int GC_WCH_SIBLING = 0x1;
            public const   int GC_WCH_CONTAINER = 0x2;
            public const   int GC_WCH_CONTAINED = 0x3;
            public const   int GC_WCH_ALL = 0x4;
            public const   int GC_WCH_FREVERSEDIR = 0x8000000;
            public const   int GC_WCH_FONLYNEXT = 0x10000000;
            public const   int GC_WCH_FONLYPREV = 0x20000000;
            public const   int GC_WCH_FSELECTED = 0x40000000;
            public const   int OLECONTF_EMBEDDINGS = 0x1;
            public const   int OLECONTF_LINKS = 0x2;
            public const   int OLECONTF_OTHERS = 0x4;
            public const   int OLECONTF_ONLYUSER = 0x8;
            public const   int OLECONTF_ONLYIFRUNNING = 0x10;
            public const   int ALIGN_MIN = 0x0;
            public const   int ALIGN_NO_CHANGE = 0x0;
            public const   int ALIGN_TOP = 0x1;
            public const   int ALIGN_BOTTOM = 0x2;
            public const   int ALIGN_LEFT = 0x3;
            public const   int ALIGN_RIGHT = 0x4;
            public const   int ALIGN_MAX = 0x4;
            public const   int OLEVERBATTRIB_NEVERDIRTIES = 0x1;
            public const   int OLEVERBATTRIB_ONCONTAINERMENU = 0x2;
    
            public static Guid IID_IUnknown = new Guid("{00000000-0000-0000-C000-000000000046}");
        }

        [
            System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Flags=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)
        ]
        public class Util {
            public static int MAKELONG(int low, int high) {
                return (high << 16) | (low & 0xffff);
            }
    
            public static IntPtr MAKELPARAM(int low, int high) {
                return (IntPtr) ((high << 16) | (low & 0xffff));
            }
    
            public static int HIWORD(int n) {
                return (n >> 16) & 0xffff;
            }
    
            public static int HIWORD(IntPtr n) {
                return HIWORD( (int) n );
            }
    
            public static int LOWORD(int n) {
                return n & 0xffff;
            }
    
            public static int LOWORD(IntPtr n) {
                return LOWORD( (int) n );
            }
    
            public static int SignedHIWORD(IntPtr n) {
                return SignedHIWORD( (int) n );
            }
            public static int SignedLOWORD(IntPtr n) {
                return SignedLOWORD( (int) n );
            }
            
            public static int SignedHIWORD(int n) {
                int i = (int)(short)((n >> 16) & 0xffff);
    
                return i;
            }
    
            public static int SignedLOWORD(int n) {
                int i = (int)(short)(n & 0xFFFF);
                
                return i;
            }
    
            /// <devdoc>
            ///     Computes the string size that should be passed to a typical Win32 call.
            ///     This will be the character count under NT, and the ubyte count for Windows 95.
            /// </devdoc>
            public static int GetPInvokeStringLength(String s) {
                if (s == null) {
                    return 0;
                }
    
                if (Marshal.SystemDefaultCharSize == 2) {
                    return s.Length;
                }
                else {
                    if (s.Length == 0) {
                        return 0;
                    }
                    if (s.IndexOf('\0') > -1) {
                        return GetEmbededNullStringLengthAnsi(s);
                    }
                    else {
                        return lstrlen(s);
                    }
                }
            }
    
            private static int GetEmbededNullStringLengthAnsi(String s) {
                int n = s.IndexOf('\0');
                if (n > -1) {
                    String left = s.Substring(0, n);
                    String right = s.Substring(n+1);
                    return GetPInvokeStringLength(left) + GetEmbededNullStringLengthAnsi(right) + 1;
                }
                else {
                    return GetPInvokeStringLength(s);
                }
            }
    
            [DllImport(ExternDll.Kernel32, CharSet=CharSet.Auto)]
            private static extern int lstrlen(String s);
    
            [DllImport(ExternDll.User32, CharSet=CharSet.Auto)]
            internal static extern int RegisterWindowMessage(string msg);
        }

        public enum  tagTYPEKIND {
            TKIND_ENUM = 0,
            TKIND_RECORD = 1,
            TKIND_MODULE = 2,
            TKIND_INTERFACE = 3,
            TKIND_DISPATCH = 4,
            TKIND_COCLASS = 5,
            TKIND_ALIAS = 6,
            TKIND_UNION = 7,
            TKIND_MAX = 8
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public class  tagTLIBATTR {
            public   Guid guid = new Guid();
            [MarshalAs(UnmanagedType.U4)]
            public   int lcid = 0;
            public   NativeMethods.tagSYSKIND syskind = new NativeMethods.tagSYSKIND();
            [MarshalAs(UnmanagedType.U2)]
            public   short wMajorVerNum = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short wMinorVerNum = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short wLibFlags = 0;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public  class  tagTYPEDESC {
            public   IntPtr unionMember = IntPtr.Zero;
            public   short vt = 0;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct  tagPARAMDESC {
            public   IntPtr pparamdescex;
            
            [MarshalAs(UnmanagedType.U2)]
            public   short wParamFlags;
        }
    
        public sealed class CommonHandles {
            /// <devdoc>
            ///     Handle type for accelerator tables.
            /// </devdoc>
            public static readonly int Accelerator  = HandleCollector.RegisterType("Accelerator", 80, 50);
    
            /// <devdoc>
            ///     handle type for cursors.
            /// </devdoc>
            public static readonly int Cursor       = HandleCollector.RegisterType("Cursor", 20, 500);
    
            /// <devdoc>
            ///     Handle type for enhanced metafiles.
            /// </devdoc>
            public static readonly int EMF          = HandleCollector.RegisterType("EnhancedMetaFile", 20, 500);
    
            /// <devdoc>
            ///     Handle type for file find handles.
            /// </devdoc>
            public static readonly int Find         = HandleCollector.RegisterType("Find", 0, 1000);
    
            /// <devdoc>
            ///     Handle type for GDI objects.
            /// </devdoc>
            public static readonly int GDI          = HandleCollector.RegisterType("GDI", 90, 50);
    
            /// <devdoc>
            ///     Handle type for HDC's that count against the Win98 limit of five DC's.  HDC's
            ///     which are not scarce, such as HDC's for bitmaps, are counted as GDIHANDLE's.
            /// </devdoc>
            public static readonly int HDC          = HandleCollector.RegisterType("HDC", 100, 2); // wait for 2 dc's before collecting
    
            /// <devdoc>
            ///     Handle type for icons.
            /// </devdoc>
            public static readonly int Icon         = HandleCollector.RegisterType("Icon", 20, 500);
    
            /// <devdoc>
            ///     Handle type for kernel objects.
            /// </devdoc>
            public static readonly int Kernel       = HandleCollector.RegisterType("Kernel", 0, 1000);
    
            /// <devdoc>
            ///     Handle type for files.
            /// </devdoc>
            public static readonly int Menu         = HandleCollector.RegisterType("Menu", 30, 1000);
    
            /// <devdoc>
            ///     Handle type for windows.
            /// </devdoc>
            public static readonly int Window       = HandleCollector.RegisterType("Window", 5, 1000);
        }
    
        public enum  tagSYSKIND {
            SYS_WIN16 = 0,
            SYS_MAC = 2
        }
    
        public delegate bool MonitorEnumProc(IntPtr monitor, IntPtr hdc, IntPtr lprcMonitor, IntPtr lParam);
    
        [ComImport(), Guid("A7ABA9C1-8983-11cf-8F20-00805F2CD064"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IProvideMultipleClassInfo {
             // since the inheritance doesn't seem to work...
             // these are from IProvideClassInfo & IProvideClassInfo2
             [PreserveSig]
             UnsafeNativeMethods.ITypeInfo GetClassInfo();
             
             [PreserveSig]
             int GetGUID(int dwGuidKind, [In, Out] ref Guid pGuid);
         
             [PreserveSig]
             int GetMultiTypeInfoCount([In, Out] ref int pcti);
         
             // we use arrays for most of these since we never use them anyway.
             [PreserveSig]
             int GetInfoOfIndex(int iti, int dwFlags, 
                                [In, Out]
                                ref UnsafeNativeMethods.ITypeInfo pTypeInfo, 
                                int       pTIFlags,
                                int       pcdispidReserved,
                                IntPtr piidPrimary,
                                IntPtr piidSource);
       }
   
        [StructLayout(LayoutKind.Sequential)]
            public class EVENTMSG {
            public int message = 0;
            public IntPtr paramL = IntPtr.Zero;
            public IntPtr paramH = IntPtr.Zero;
            public int time = 0;
            public IntPtr hwnd = IntPtr.Zero;
        }
    
        [ComImport(), Guid("B196B283-BAB4-101A-B69C-00AA00341D07"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IProvideClassInfo {
            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethods.ITypeInfo GetClassInfo();
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public  sealed class  tagTYPEATTR {
            public Guid guid = new Guid();
            [MarshalAs(UnmanagedType.U4)]
            public   int lcid = 0;
            [MarshalAs(UnmanagedType.U4)]
            public   int dwReserved = 0;
            public   int memidConstructor = 0;
            public   int memidDestructor = 0;
            public   IntPtr lpstrSchema = IntPtr.Zero;
            [MarshalAs(UnmanagedType.U4)]
            public   int cbSizeInstance = 0;
            public   int typekind = 0; // NativeMethods.tagTYPEKIND
            [MarshalAs(UnmanagedType.U2)]
            public   short cFuncs = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short cVars = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short cImplTypes = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short cbSizeVft = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short cbAlignment = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short wTypeFlags = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short wMajorVerNum = 0;
            [MarshalAs(UnmanagedType.U2)]
            public   short wMinorVerNum = 0;
            
            // Microsoft these are inline too
            //public    NativeMethods.tagTYPEDESC tdescAlias;
            [MarshalAs(UnmanagedType.U4)]
            public   int tdescAlias_unionMember = 0;
            
            [MarshalAs(UnmanagedType.U2)]
            public   short tdescAlias_vt = 0;
            
            //public    NativeMethods.tagIDLDESC idldescType;
            [MarshalAs(UnmanagedType.U4)]
            public   int idldescType_dwReserved = 0;
            
            [MarshalAs(UnmanagedType.U2)]
            public   short idldescType_wIDLFlags = 0;
            
            
            public tagTYPEDESC Get_tdescAlias(){
                tagTYPEDESC td = new tagTYPEDESC();
                td.unionMember = (IntPtr)this.tdescAlias_unionMember;
                td.vt = this.tdescAlias_vt;
                return td;
            }
            
            public tagIDLDESC Get_idldescType(){
                tagIDLDESC id = new tagIDLDESC();
                id.dwReserved = this.idldescType_dwReserved;
                id.wIDLFlags = this.idldescType_wIDLFlags;
                return id;
            } 
        }
            
        public enum tagVARFLAGS {
             VARFLAG_FREADONLY         =    1,
             VARFLAG_FSOURCE           =    0x2,
             VARFLAG_FBINDABLE         =    0x4,
             VARFLAG_FREQUESTEDIT      =    0x8,
             VARFLAG_FDISPLAYBIND      =    0x10,
             VARFLAG_FDEFAULTBIND      =    0x20,
             VARFLAG_FHIDDEN           =    0x40,
             VARFLAG_FDEFAULTCOLLELEM  =    0x100,
             VARFLAG_FUIDEFAULT        =    0x200,
             VARFLAG_FNONBROWSABLE     =    0x400,
             VARFLAG_FREPLACEABLE      =    0x800,
             VARFLAG_FIMMEDIATEBIND    =    0x1000
       }
   
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagELEMDESC {
            public    NativeMethods.tagTYPEDESC tdesc = new NativeMethods.tagTYPEDESC();
            public    NativeMethods.tagPARAMDESC paramdesc = new NativeMethods.tagPARAMDESC();
        }
        
        public enum  tagVARKIND {
            VAR_PERINSTANCE = 0,
            VAR_STATIC = 1,
            VAR_CONST = 2,
            VAR_DISPATCH = 3
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct  tagIDLDESC {
            [MarshalAs(UnmanagedType.U4)]
            public   int dwReserved;
            [MarshalAs(UnmanagedType.U2)]
            public   short wIDLFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RGBQUAD {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFO_ARRAY {
            public BITMAPINFOHEADER bmiHeader = new BITMAPINFOHEADER();

            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=BITMAPINFO_MAX_COLORSIZE*4)]
            public byte[] bmiColors = null; // RGBQUAD structs... Blue-Green-Red-Reserved, repeat...
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PALETTEENTRY {
            public byte peRed;
            public byte peGreen;
            public byte peBlue;
            public byte peFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFO_FLAT {
            public int      bmiHeader_biSize;// = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
            public int      bmiHeader_biWidth;
            public int      bmiHeader_biHeight;
            public short    bmiHeader_biPlanes;
            public short    bmiHeader_biBitCount;
            public int      bmiHeader_biCompression;
            public int      bmiHeader_biSizeImage;
            public int      bmiHeader_biXPelsPerMeter;
            public int      bmiHeader_biYPelsPerMeter;
            public int      bmiHeader_biClrUsed;
            public int      bmiHeader_biClrImportant;

            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=BITMAPINFO_MAX_COLORSIZE*4)]
            public byte[] bmiColors; // RGBQUAD structs... Blue-Green-Red-Reserved, repeat...
        }

        /// <devdoc>
        ///     This method takes a file URL and converts it to a local path.  The trick here is that
        ///     if there is a '#' in the path, everything after this is treated as a fragment.  So
        ///     we need to append the fragment to the end of the path.
        /// </devdoc>
        internal static string GetLocalPath(string fileName) {
            System.Diagnostics.Debug.Assert(fileName != null && fileName.Length > 0, "Cannot get local path, fileName is not valid");

            Uri uri = new Uri(fileName, true);
            return uri.LocalPath + uri.Fragment;
        }
*/
    }
}

