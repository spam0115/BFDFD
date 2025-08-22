' =======================================================
' Big Fast Duplicate File Deleter! (BFDFD)
' Copyright (c) 2025 Zhi Wong
' https://github.com/spam0115/BFDFD
' =======================================================


' Big Fast Duplicate File Deleter! is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 3 of the License, or
' (at your option) any later version.
'
' Big Fast Duplicate File Deleter! is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with Big Fast Duplicate File Deleter!; if not, see http://www.gnu.org/licenses/.


Option Strict Off

Imports Native.Api.NativeConstants

Namespace Native.Api

    Public Class NativeEnums

#Region "Declarations used for tokens & privileges"

        Public Enum ElevationType
            [Default] = 1
            Full = 2
            Limited = 3
        End Enum

#End Region

#Region "Declarations used for files"

        <Flags()> _
        Public Enum HChangeNotifyEventID
            ' <summary>
            ' All events have occurred. 
            ' </summary>
            SHCNE_ALLEVENTS = &H7FFFFFFF

            ' <summary>
            ' A file type association has changed. <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> 
            ' must be specified in the <i>uFlags</i> parameter. 
            ' <i>dwItem1</i> and <i>dwItem2</i> are not used and must be <see langword="null"/>. 
            ' </summary>
            SHCNE_ASSOCCHANGED = &H8000000

            ' <summary>
            ' The attributes of an item or folder have changed. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the item or folder that has changed. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>.
            ' </summary>
            SHCNE_ATTRIBUTES = &H800

            ' <summary>
            ' A nonfolder item has been created. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the item that was created. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>.
            ' </summary>
            SHCNE_CREATE = &H2

            ' <summary>
            ' A nonfolder item has been deleted. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the item that was deleted. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_DELETE = &H4

            ' <summary>
            ' A drive has been added. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the root of the drive that was added. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_DRIVEADD = &H100

            ' <summary>
            ' A drive has been added and the Shell should create a new window for the drive. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the root of the drive that was added. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_DRIVEADDGUI = &H10000

            ' <summary>
            ' A drive has been removed. <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the root of the drive that was removed.
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_DRIVEREMOVED = &H80

            ' <summary>
            ' Not currently used. 
            ' </summary>
            SHCNE_EXTENDED_EVENT = &H4000000

            ' <summary>
            ' The amount of free space on a drive has changed. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the root of the drive on which the free space changed.
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_FREESPACE = &H40000

            ' <summary>
            ' Storage media has been inserted into a drive. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the root of the drive that contains the new media. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_MEDIAINSERTED = &H20

            ' <summary>
            ' Storage media has been removed from a drive. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the root of the drive from which the media was removed. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_MEDIAREMOVED = &H40

            ' <summary>
            ' A folder has been created. <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> 
            ' or <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the folder that was created. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_MKDIR = &H8

            ' <summary>
            ' A folder on the local computer is being shared via the network. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the folder that is being shared. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_NETSHARE = &H200

            ' <summary>
            ' A folder on the local computer is no longer being shared via the network. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the folder that is no longer being shared. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_NETUNSHARE = &H400

            ' <summary>
            ' The name of a folder has changed. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the previous pointer to an item identifier list (PIDL) or name of the folder. 
            ' <i>dwItem2</i> contains the new PIDL or name of the folder. 
            ' </summary>
            SHCNE_RENAMEFOLDER = &H20000

            ' <summary>
            ' The name of a nonfolder item has changed. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the previous PIDL or name of the item. 
            ' <i>dwItem2</i> contains the new PIDL or name of the item. 
            ' </summary>
            SHCNE_RENAMEITEM = &H1

            ' <summary>
            ' A folder has been removed. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the folder that was removed. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_RMDIR = &H10

            ' <summary>
            ' The computer has disconnected from a server. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the server from which the computer was disconnected. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' </summary>
            SHCNE_SERVERDISCONNECT = &H4000

            ' <summary>
            ' The contents of an existing folder have changed 
            ' but the folder still exists and has not been renamed. 
            ' <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or 
            ' <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>. 
            ' <i>dwItem1</i> contains the folder that has changed. 
            ' <i>dwItem2</i> is not used and should be <see langword="null"/>. 
            ' If a folder has been created deleted or renamed use SHCNE_MKDIR SHCNE_RMDIR or 
            ' SHCNE_RENAMEFOLDER respectively instead. 
            ' </summary>
            SHCNE_UPDATEDIR = &H1000

            ' <summary>
            ' An image in the system image list has changed. 
            ' <see cref="HChangeNotifyFlags.SHCNF_DWORD"/> must be specified in <i>uFlags</i>. 
            ' </summary>
            SHCNE_UPDATEIMAGE = &H8000
        End Enum

        <Flags()> _
        Public Enum HChangeNotifyFlags
            ' <summary>
            ' The <i>dwItem1</i> and <i>dwItem2</i> parameters are DWORD values. 
            ' </summary>
            SHCNF_DWORD = &H3
            ' <summary>
            ' <i>dwItem1</i> and <i>dwItem2</i> are the addresses of ITEMIDLIST structures that 
            ' represent the item(s) affected by the change. 
            ' Each ITEMIDLIST must be relative to the desktop folder. 
            ' </summary>
            SHCNF_IDLIST = &H0
            ' <summary>
            ' <i>dwItem1</i> and <i>dwItem2</i> are the addresses of null-terminated strings of 
            ' maximum length MAX_PATH that contain the full path names 
            ' of the items affected by the change. 
            ' </summary>
            SHCNF_PATHA = &H1
            ' <summary>
            ' <i>dwItem1</i> and <i>dwItem2</i> are the addresses of null-terminated strings of 
            ' maximum length MAX_PATH that contain the full path names 
            ' of the items affected by the change. 
            ' </summary>
            SHCNF_PATHW = &H5
            ' <summary>
            ' <i>dwItem1</i> and <i>dwItem2</i> are the addresses of null-terminated strings that 
            ' represent the friendly names of the printer(s) affected by the change. 
            ' </summary>
            SHCNF_PRINTERA = &H2
            ' <summary>
            ' <i>dwItem1</i> and <i>dwItem2</i> are the addresses of null-terminated strings that 
            ' represent the friendly names of the printer(s) affected by the change. 
            ' </summary>
            SHCNF_PRINTERW = &H6
            ' <summary>
            ' The function should not return until the notification 
            ' has been delivered to all affected components. 
            ' As this flag modifies other data-type flags it cannot by used by itself.
            ' </summary>
            SHCNF_FLUSH = &H1000
            ' <summary>
            ' The function should begin delivering notifications to all affected components 
            ' but should return as soon as the notification process has begun. 
            ' As this flag modifies other data-type flags it cannot by used by itself.
            ' </summary>
            SHCNF_FLUSHNOWAIT = &H2000
        End Enum

        Public Enum FO_Func As UInteger
            FO_MOVE = &H1
            FO_COPY = &H2
            FO_DELETE = &H3
            FO_RENAME = &H4
        End Enum

        <Flags()> _
        Public Enum FILEOP_FLAGS_ENUM As UShort
            FOF_MULTIDESTFILES = &H1
            FOF_CONFIRMMOUSE = &H2
            FOF_SILENT = &H4
            ' don't create progress/report
            FOF_RENAMEONCOLLISION = &H8
            FOF_NOCONFIRMATION = &H10
            ' Don't prompt the user.
            FOF_WANTMAPPINGHANDLE = &H20
            ' Fill in SHFILEOPSTRUCT.hNameMappings
            ' Must be freed using SHFreeNameMappings
            FOF_ALLOWUNDO = &H40
            FOF_FILESONLY = &H80
            ' on *.*, do only files
            FOF_SIMPLEPROGRESS = &H100
            ' means don't show names of files
            FOF_NOCONFIRMMKDIR = &H200
            ' don't confirm making any needed dirs
            FOF_NOERRORUI = &H400
            ' don't put up error UI
            FOF_NOCOPYSECURITYATTRIBS = &H800
            ' dont copy NT file Security Attributes
            FOF_NORECURSION = &H1000
            ' don't recurse into directories.
            FOF_NO_CONNECTED_ELEMENTS = &H2000
            ' don't operate on connected elements.
            FOF_WANTNUKEWARNING = &H4000
            ' during delete operation, warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
            FOF_NORECURSEREPARSE = &H8000
            ' treat reparse points as objects, not containers
        End Enum

        Public Enum EFileAccess
            _GenericRead = &H80000000
            _GenericWrite = &H40000000
            _GenericExecute = &H20000000
            _GenericAll = &H10000000
        End Enum

        Public Enum EMoveMethod As UInteger
            FILE_BEGIN = 0
            FILE_CURRENT = 1
            FILE_END = 2
        End Enum

        Public Enum EFileShare
            _None = &H0
            _Read = &H1
            _Write = &H2
            _Delete = &H4
        End Enum

        Public Enum ECreationDisposition
            _New = 1
            _CreateAlways = 2
            _OpenExisting = 3
            _OpenAlways = 4
            _TruncateExisting = 5
        End Enum

        Public Enum EFileAttributes
            _Readonly = &H1
            _Hidden = &H2
            _System = &H4
            _Directory = &H10
            _Archive = &H20
            _Device = &H40
            _Normal = &H80
            _Temporary = &H100
            _SparseFile = &H200
            _ReparsePoint = &H400
            _Compressed = &H800
            _Offline = &H1000
            _NotContentIndexed = &H2000
            _Encrypted = &H4000
            _Write_Through = &H80000000
            _Overlapped = &H40000000
            _NoBuffering = &H20000000
            _RandomAccess = &H10000000
            _SequentialScan = &H8000000
            _DeleteOnClose = &H4000000
            _BackupSemantics = &H2000000
            _PosixSemantics = &H1000000
            _OpenReparsePoint = &H200000
            _OpenNoRecall = &H100000
            _FirstPipeInstance = &H80000
        End Enum

        <Flags()> _
        Public Enum ShellExecuteInfoMask As Integer
            SEE_MASK_INVOKEIDLIST = &HC
            SEE_MASK_NOCLOSEPROCESS = &H40
            SEE_MASK_FLAG_NO_UI = &H400
        End Enum

#End Region

#Region "Declarations used for windowS"

        Public Enum ShowWindowType As UInteger
            Hide = 0
            ShowNormal = 1
            Normal = 1
            ShowMinimized = 2
            ShowMaximized = 3
            Maximize = 3
            ShowNoActivate = 4
            Show = 5
            Minimize = 6
            ShowMinNoActive = 7
            ShowNa = 8
            Restore = 9
            ShowDefault = 10
            ForceMinimize = 11
            Max = 11
        End Enum

#End Region

    End Class

End Namespace
