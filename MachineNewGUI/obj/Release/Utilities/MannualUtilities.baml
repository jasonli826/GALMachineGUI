   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GALNewGUI.UtilitiesGALNewGUI.Utilities  *    $GALNewGUI.Utilities.MannualUtilities   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:GALNewGUI.Utilities     -     � Title$  MannualUtilities��$	��650��$
��1000������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ #007ACC�� � Offset$ 0Q�� $ #FFD500��$	 0.5Q�� $ #00C9FF��$ 1Q� � 	Resources  �� MergedDictionaries �� Source��  �� $ ../Resources/Themes.xaml?�%    .���  � ColumnDefinitions �� $��9* ��� .+��� $��20,20,20,20q�$��2��.@��� ���� 	 �� Orientation$	 
Horizontal=�$��32��.+��� $��../Images/InputTray.png��$��20��$��20��$��Center=��� $��
Input Tray��$��Center=�$��5,0,0,0q�$��14(�.��� .+�� 
 � Orientation$
 Vertical=�.+��� $	 
Horizontal=�.+�� .+��� $��
Input Tray��$	��420��$	��650�� �� Left$ 10��$��10q�
 �� Top$ 30��.���� .+�� $	��600��$	��120��
������� �� �� $
��0.6* ��� �� $
��0.6* ���  � RowDefinitions �� �� .+��� -   $��buttonLoadTray��   ModernButton#��[  $��4��$��0��.��
LoadTray�� -   $��buttonUnloadTray��#��[  $��0��$��0��.��
UnloadTray�� -   $��buttonLoadPos��#��[  $��4��$��1��.��	LoadPos�� -   $��buttonPickPos��#��[  $��2��$��1��.��	PickPos�� -   $��buttonUnLoadPos��#��[  $��0��$��1��.��	UnloadPos�� -   $��canvasInTray��$	��300��$	��200��$ 0��$	 140��.+��� 
���   � �� StrokeEndLineCap$ Triangle=�$��10��	 �� X1$ 0��	 �� Y1$ -5��	 �� X2$ 0��	 �� Y2$	 100�� K� ZIndex$ 1���� 
���   �$ Triangle=�$��10��$ 0��$ 0��$	 100��$ 0��$ 1��� -   $��polygonInTray��
�������
���**�� J� Opacity$	 0.3Q� � Points- �    �� ���+S�I �� ��$ 0��$ 0��� $	��300��$	��180��
�������$	 318��$	 160�� �� �� ��  �� $
��0.7* ��� $
��0.6* ��� .+��� $��0��$��0��$��18(�.��Column�� -	   $��comboBoxShuttlePalletCol��$��1��$��0��$��10q� �� SelectedIndex$ 0���� $��0��$��1��$��18(�.��Row�� -
   $��comboBoxShuttlePalletRow��$��1��$��1��$��10q�$ 0���� -   $��buttonShuttlePalletMove��  
stopButton#��[ $��2��$��0��.��Move�� -   $��buttonShuttlePalletPick��#��[ $��2��$��1��.��Pick�� ���� $	 
Horizontal=�$��32��.+��� $��../Images/OutputTray.png��$��Uniform=�$��Stretch=�$
��Auto��$
��Auto���� $��Output Tray��$��Center=�$��5,0,0,0q�.��� $
 Vertical=�.+��� $	 Vertical=�.+��� $��Output Pallet��$	��650��$	��450��$��10q�.���  �� $��2* ��� $��2* ��� $��3* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��canvasOutTray��$��0��$��0��$��2��$��3��
�������$��5q�$	��300��$	��200��$ 0��.+��� 
���   �$ Triangle=�$��10��$ 0��$ -5��$ 0��$	 100��$ 1���� 
���   �$ Triangle=�$��10��$ 0��$ 0��$	 100��$ 0��$ 1��� -   $��polygonOutTray��
�������
���**��$	 0.3Q�- �    �� ���+S�I �� ��$ 10���� $��3��$��0��$��Right=�$��5q�$��Center=�$��18(�.��Column�� -   $��comboBoxOutputPalletCol��$��3��$��1��$��1q�$��30��$��50��$ 0��$
��Left=��� $��4��$��0��$��Right=�$��5q�$��Center=�$��18(�.��Row�� -   $��comboBoxOutputPalletRow��$��4��$��1��$��1q�$��30��$��50��$ 0��$
��Left=��� -   $��buttonOutPalletMove��$��0��$��2��#��[  $��5q�.��Move�� -   $��buttonOutPalletPlace��$��1��$��2��#��[  $��5q�.��Place�� -   $��buttonSpotCheck��$��2��$��2��#��[  $��5q�.��	SpotCheck�� -   $��buttonOutPalletSend��$��3��$��2��#��[ $	��120��$��5q�.��Send Pallet�� -   $��buttonOutPalletReceive��$��4��$��2��#��[ $	��120��$��5q�.��Receive Pallet�� -   $��checkboxAdaptorClamp��$��5��$��2��$��Center=�$��Center=�$��5q�.��Clamp Pallet�� ���� $	 
Horizontal=�$��32��.+��� $"��../Images/BarcodeScanner.png��$��Uniform=�$��Stretch=�$
��Auto��$
��Auto���� $��Barcode Scanner��$��Center=�$��5,0,0,0q�.��� $
 Vertical=�.+�� $��5,0,5,5q�.+��� $��📦 Barcode Scanner��$	��180��$	��680�����	#FF3B82F6$��2q�$
��Bold"�$��14(�  PrimaryColorForLogin#��[ .��� $	��640��$	��120�����	#FFE5F6FF$��10q� �� $��1* ��� $��1* ��� $��2* � �� �� .+��� $��0��$��0��$��🤖 Robot EF:��$��Center=�$��Right=�$��16(�$��10q����	#FF1E3A8A�� -   $��buttonTrayScanner��$��0��$��1��#��[  ���	#FF60A5FA
�������.��	Trigger�� -   $��textblockRbtEF��$��0��$��2��$��10q�
����������	#FF60A5FA$��1q��� $��1��$��0��$��📍 Fixed:��$��Center=�$��Right=�$��16(�$��10q����	#FF1E3A8A�� -   $��buttonPalletScanner��$��1��$��1��#��[  ���	#FF60A5FA
�������.��	Trigger�� -   $��textblockFixed��$��1��$��2��$��10q�
����������	#FF60A5FA$��1q��� ���� $	 
Horizontal=�$��32��.+��� $��../Images/Gripper.png��$��Uniform=�$��Stretch=�$
��Auto��$
��Auto���� $��Gripper Config��$��Center=�$��5,0,0,0q�.��� $
 Vertical=�.+�� $��10q� �� $��* ��� $
��Auto �.+��� $��Gripper��$��0��$	��520��$	��180��$��5q�.���  �� �� ��  �� �� �� .+��� -   $��buttonFlip0��$��0��$��0��#��[  $	��120��.��Flip Vertical�� -   $��buttonFlip90��$��1��$��0��#��[  $	��120��.��Flip Horizontal�� -   $!��buttonShuttlePalletMove2Bcd��$��0��$��1��#��[ $	��120��.��Mv2PanelBcd�� -   $��buttonShuttleMove2TrayBcd��$��1��$��1��#��[ $	��120��.��
Mv2TrayBcd�� -   $��buttonOutPalletMoveToBcd��$��2��$��1��#��[ $	��120��.��Mv2PalletBcd�� $��ToolTip Utility��$��1��$	��350��$	��180��$��5q�.���  �� �� .+��� -    $��buttonJumptoZero��$��0��#��[  $	��120��.��Jump To Zero�� -!   $��buttonCleartip1��$��1��#��[  $	��120��.��
Clear-Tip1