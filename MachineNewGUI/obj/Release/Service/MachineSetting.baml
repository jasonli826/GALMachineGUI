   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GALNewGUI.ServiceGALNewGUI.Service  &     GALNewGUI.Service.MachineSetting   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:GALNewGUI.Service     -     � Title$  MachineSetting��$	��550��$
��1200������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ #007ACC�� � Offset$ 0Q�� $ #FFD500��$	 0.5Q�� $ #00C9FF��$ 1Q� � 	Resources  �� MergedDictionaries �� Source��  �� $ ../Resources/Themes.xaml?�%    .��� .+��� $��20q�.@��� ����  �� Orientation$ 
Horizontal=�$��32��.+��� $"��../Images/MachineSetting.png��$��20��$��20��$��Center=��� $��Machine Setting��$��Center=�$��5,0,0,0q�$��14(�.���� .���� $��10q�$ Vertical=�$	��Top=�.+��� $��10q�
�����F�$��2q����� $��MACHINE CONFIG��$
��Bold"�$��20(�
�������
����  �	 �� Padding$
	 10,4q�
 �� TextAlignment$
 Center=�$��Stretch=�.���� ���#F0F8FF.+�� $��5q�
�������.+��� $��5q�$	��220��$��Center=�$��SemiBold"����#333Machine Type�� $��5q�$	��200��$	��GAL��{�.  ���#FFEFD5���#666� $��5q�
�������.+��� $��5q�$	��220��$��Center=�$��SemiBold"����#333Machine SNo�� $��5q�$	��200��$��GAL101�����#FFF8DC� $��5q�
�������.+��� $��5q�$	��220��$��Center=�$��SemiBold"����#333
Robot IP�� $��5q�$	��200��$��192.168.20.142�����#FFF8DC� $��5q�
�������.+��� $��5q�$	��220��$��Center=�$��SemiBold"����#333Robot Port No�� $��5q�$	��200��$
��2001�����#FFF8DC� -   $��WrapDeveloperMode��$��5q�
�������$y�Visible=�.+��� $��5q�$	��280��$��Center=�$��SemiBold"����#333&$Has Developer Vision Offline Testing�� -   $��ChkDeveloperMode��$��5q�$��Center=�
���  �� d� 	IsChecked �� *HasDeveloperMode+�� $��5,10,0,0q�$ 
Horizontal=�$��Center=�.+��� $
��Save��   ModernButton#��[  $��0,0,10,0q��� $��Cancel��  
stopButton#��[ �� ���� $ 
Horizontal=�$��32��.+��� $��../Images/Scanner.png��$��20��$��20��$��Center=��� $��Scanner Comm Port��$��Center=�$��5,0,0,0q�$��14(�.���� .���� $��10q�$ Vertical=�$	��Top=�.+��� $��10q�
�����F�$��2q����� $��SCANNER COM PORT��$
��Bold"�$��18(�
�������
��� ���$	 8q�$��Stretch=�$
 Center=�.���� ���#F0F8FF.+�� -   $��WrapScanner1�����#E6F2FF$��5q�.+��� $ 
Horizontal=�.+�� .+��� $��5q�$	��150��$��SemiBold"����#333RBT EF Scanner :� .+��� -    ��Name$ sp_scanner1Serial��$ 
Horizontal=����#F5FFFA$��3q�.+��� $��5q�$��40��$��Right=����#333COM�� $��5q�$	��100��$��1�����#F0FFF0�� $��5q�$	��100�����#333
Baudrate�� $��5q�$	��100��$
��9600�����#F0FFF0�� $ 
Horizontal=�$��3q�.+��� $��5q�$	��100�����#333Model�� -   $��comboboxloader1��$	��190��$��5q�$��25��
�������� -   $��WrapScanner2�����#E6FFE6$��5q�.+��� $ 
Horizontal=�.+�� .+��� $��5q�$	��150��$��SemiBold"����#333Fixed Scanner :� .+��� -   $ sp_scanner2Serial��$ 
Horizontal=����#F0FFF0$��3q�.+��� $��5q�$��40��$��Right=����#333COM�� $��5q�$	��100��$��1�����#F0FFF0�� $��5q�$	��100�����#333
Baudrate�� $��5q�$	��100��$
��9600�����#F0FFF0�� $ 
Horizontal=�$��3q�.+��� $��5q�$	��100�����#333Model�� -	   $��comboboxloader2��$	��190��$��5q�$��25��
�������� $��5q�.+��� $��5q�$��Italic$�
���iii�%#DataBits 7, Parity Even, Stop bit 1�� $��5,10,0,0q�$ 
Horizontal=�$��Center=�.+��� $
��Save��#��[  $��0,0,10,0q��� -
   $��Cancel��#��[ �� ���� $ 
Horizontal=�$��32��.+��� $��../Images/Light.png��$��20��$��20��$��Center=��� $��TOWER LIGHT CONFIG��$��Center=�$��5,0,0,0q�$��14(�.���� -    ��Name$ gblightconfig��$��10q�$��10q����	#FFFDF5E6
��� ���$��2q����� $��TOWER LIGHT CONFIG��$
��Bold"�$��22(�
��� ���$��Center=�$	��0,5q�.���� .+�A�  A� Rows$ 1�� A� Columns$ 7��$��10,10q�$
��Left=�.+��� $��State��$	��150��$
��Bold"�$��16(�$��Center=��� $��Green��$	��150��$��16(�$
��Bold"�
�������
���"�"�$
 Center=�$	 5q��� $��Amber��$	��150��$��16(�$
��Bold"�
���   �
��� ���$
 Center=�$	 5q��� $	��Red��$	��150��$��16(�$
��Bold"�
�������
���<��$
 Center=�$	 5q��� $
��Blue��$	��150��$��16(�$
��Bold"�
�������
����iA�$
 Center=�$	 5q��� $��Buzzer��$	��150��$��16(�$
��Bold"�
���   ����	#FFDDDDDD$
 Center=�$	 5q��� $��Reset��#��[ $
��Bold"�$��5q�$��5q�$��1q� � Cursor$
 Hand������ *ResetTowerLightCommand+