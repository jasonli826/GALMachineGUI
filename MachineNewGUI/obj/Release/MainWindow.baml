   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GALNewGUI	GALNewGUI      GALNewGUI.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:GALNewGUI     -     � Title$  
MainWindow��$
��1000��$
��1600�� � WindowState$ 	Maximized=� � 	Resources  �� MergedDictionaries �� Source��  �� $ Resources\Themes.xaml?�%    .��]� .+�o� -   $��mainMenu�� o� 
IsMainMenu . $	��Top=�.@�m� -   $��menuProduct������  �� Orientation$ 
Horizontal=�$��Center=�$��35��$	��160��$��2q�.+��� $��Images/Product.png��$��35��$��60��$	��5,0q��� $��Product��$��Center=�
�������$��22(�$
��Bold"�$��0,0,0,0q�.@�m� -   $��menuLoadProduct��$��Load Product��m� -   $��menuEditProduct��$��Edit Product��m� -   $��menuNewProduct��$��New Product��m� -   $��menuUtilities������ $ 
Horizontal=�$��Center=�$��35��$	��160��$��2q�.+��� $��Images/Utility.png��$��35��$��60��$	��5,0q��� $��Utility��$��Center=�
�������$��22(�$
��Bold"�$��0,0,0,0q�.@�m� -   $��menuManualUtility��$��Manual Utility��m� -	   $��menuIo_load��$��
IO Utility��m� -
   $��menuUserMgmt������ $ 
Horizontal=�$��Center=�$��35��$	��120��$��3q�.+��� $��Images/Password.png��$��40��$��35��$	��5,0q��� $
��User��$��Center=�
�������$��22(�$
��Bold"�$��0,0,0,0q�.@�m� -   $��	menuLogin��$��Login��m� -   $��
menuLogout��$��Logout��m� -   $��menuManageUser��$��Manage User��m� -   $��menuService������ $ 
Horizontal=�$��Center=�$��35��$	��150��$��3q�.+��� $��Images/Service.png��$��35��$��60��$	��5,0q��� $��Service��$��Center=�
�������$��22(�$
��Bold"�$��0,0,0,0q�.@�m� -   $��menuRobotTeachUtil��$��Robot Teach Utility��m� -   $��ServerDriveUtil��$��Server Drive Utility��m� -   $��TooltipCaliUtil��$!��ToolTip Calibration Utility��m� -   $��MachineSettings��$��Machine Settings��m� -   $��menuHelp������ $ 
Horizontal=�$��Center=�$��35��$	��150��$��3q�.+��� $��Images/Help.png��$��40��$��50��$	��5,0q��� $
��Help��$��Center=�
�������$��22(�$
��Bold"�$��0,0,0,0q�.@�m� -   $��	menuAbout��$��About��m� -   $��
menuManual��$��User Manuals���  � ColumnDefinitions �� $��0 ��� $��* �.+�� $��1��$��5q� � RowDefinitions �� $
��Auto ��� $��* �.+��  �� $
��4.8* ��� $
��5.2* �.+��� $��Machine Operation��$��0������ 	 �� 
StartPoint$		 0,0&�
 �� EndPoint$	
 1,0&�.���  � Offset$ 0Q� � Color$ 
PowderBlue��� $ 1Q�$ Cornsilk��.���� .+��  � Orientation$ 
Horizontal=�$
��Left=�.+��� -   $��connectionStatusImage��$��Center=�$��Center=�$y�Visible=�$	��100��$��80������  �� 	UriSource$! Images/RoboticConnected.png?��� -   $��labelRobotConnection1��$��Robot 1 Connected��$��5q�
�������
��� � �$��16(�$
��Bold"�$	��210��$��32��$��Center=�� -   $��wrapMachineOperations��.+��� -   $��	buttonRun��   ModernButton#��[  $��18q�{�.  � ToolTip$	 Run��$��80��.���� $��Images/btnRun.png��$
��Fill=��� -   $��
buttonStop��  
stopButton#��[ $��18q�{�. $��80��$
 Stop��.���� $��Images/btnStop.png��$
��Fill=��� -   $��buttonLoadBatch��#��[  $��18q�$��80��$ 
Batch Load��.���� $��Images/LoadBatch.png��$
��Fill=��� -   $��checkboxDryRun��$��5q�
�������
���i��$��16(�$
��Bold"�$	��100��$��Center=�$y�Visible=� d� 	IsChecked ��  �� Path$ IsDryRun�.��	Dry Run�� -   $��checkboxSelfRun��$��5q�
�������
���i��$��16(�$
��Bold"�$	��100��$��Center=�$y�Visible=� �� $ 	IsSelfRun�.��
Self Run�� -   $��sp_sliderRobotSpeed��$ 
Horizontal=�
�������$��5q�$y�Visible=�.+��� $��Center=�$��16(�$
��Bold"�
���i��$��0q�Robot Speed (%)�� -   $��sliderRobotSpeed��$��Center=� � Maximum$	 100Q� � Minimum$ 10Q� �� TickPlacement$ BottomRight=� �� TickFrequency$ 10Q�$	��180�� �� IsSnapToTickEnabled .  � Value$	 100Q��� $��Center=�$��10q�����  �� ElementName$ sliderRobotSpeed��$ Value�� .+��� -    $��labelproductfile��$��Product File:��$��0,5,0,5q�
�������
��� � �$��16(�$
��Bold"�$	��110��$��32��$��Center=��� -!   $��txtProductName��$)��#C:\GAL\Product Files\NewProduct.xml��$��0,5,5,5q�
�������
��� � �$��16(�$
��Bold"�$
��Auto��$��32��$��Center=��� $��SECS/GEM Operations��$��1������ $		 0,0&�$	
 1,0&�.��� $ 0Q�$ 
PowderBlue��� $ 1Q�$ Cornsilk��.��� $��10q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� $��Socket Status:��$��0��$��0��$��16(�$
��Bold"��� $��0��$��1��
��� � �$��16(�$
��Bold"����� $ SocketStatus��� $��Host Comm Status:��$��0��$��2��$��16(�$
��Bold"��� $��0��$��3��
��� � �$��16(�$
��Bold"����� $ 
CommStatus��� $��Control Status:��$��1��$��0��$��16(�$
��Bold"��� $��1��$��1��
��� � �$��16(�$
��Bold"����� $ ControlStatus��� $��Process State:��$��1��$��2��$��16(�$
��Bold"��� $��1��$��3��
��� � �$��16(�$
��Bold"����� $ ProcessState��� $��
PJ Status:��$��2��$��0��$��16(�$
��Bold"��� $��2��$��1��
��� � �$��16(�$
��Bold"�$��3������ $ PJJobStatus��� $��PJ ID:��$��3��$��0��$��16(�$
��Bold"��� $��3��$��1��
��� � �$��16(�$
��Bold"�$��3������ $ PJJobStatus��� $��5��$��1��$��4��$ 
Horizontal=�$��Center=�.+��� -"   $��buttonEqConnect��#��[  $��10q�{��� $ IsConnected�.��	Connect�� -#   $��buttonEqDisconnect��#��[ $��10q�.��
Disconnect�� -$   $��buttonEqRemote��#��[ $��10q�{��� $ IsRemote�.��Remote�� -%   $��buttonEqLocal��#��[  $��10q�{��� $ IsLocal�.��Local� $��1�� �� $
��7.3* ��� $
��2.7* � �� $
��auto �.+��� $��Batch Parameter��$��1��$��0������ $		 0,0&�$	
 1,0&�.��� $ 0Q�$ 	LightCyan��� $ 1Q�$ Silver��.���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $��Reservation No:��$��0��$��0��$��Center=��� $��0��$��1��$	��150��$��	107005074���� $��	Batch No:��$��1��$��0��$��Center=��� $��1��$��1��$	��150��$��
CBNGF2Q001���� $��Module From Factor:��$��2��$��0��$��Center=��� $��2��$��1��$��New Product��$	��150���� $��
Prod Name:��$��3��$��0��$��Center=��� $��3��$��1��$��M5��$	��150���� $��Prod Height:��$��4��$��0��$��Center=��� $��4��$��1��$	��150��$
��2.15���� $��Prod Length:��$��5��$��0��$��Center=��� $��5��$��1��$	��150��$��2���� $��Prod Width:��$��6��$��0��$��Center=��� $��6��$��1��$	��150��$��2���� $
��Logs��$��0��$��0��$��Stretch=�$��Stretch=���� $��Stretch=�$��Stretch=� �� $��5 ��� $��* �.+��� $��0��
������ $��Stretch=��� -&   $��
textboxLog��$��1��$��0q�$	��500��$	��Top=�$��Stretch=�$��Stretch=� �� TextWrapping$
 Wrap=� �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�.������ $		 0,0&�$	
 1,0&�.��� $ 0Q�$ AntiqueWhite��� $ 1Q�$ GreenYellow��.��