   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GALNewGUI.ControlsGALNewGUI.Controls  %    GALNewGUI.Controls.GripperPlace   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:GALNewGUI.Controls     $
��auto��$
��auto��  � 	Resources   �� 
TargetType �� Property �� Value��%/   '��       �� " ��.���  � ��
 � � �.���� -   $��Gripper��$
��Bold"�.��� $��10q� � ColumnDefinitions �� $	��180 ��� $	��310 ��� $	��220 ��� $��* �.+��� $��0��$��5q�.+��� $��Description��$
��Bold"��� -    ��Name$ txtDesc��$��0,5,0,0q����� *Description+�� $��Offsets��$��1��$��5q�$��Stretch=�$
��Auto��.���� $��5q�.+�A�  A� Columns$ 2�� A� Rows$ 2��$��0,0,0,5q�.+��� $��Place Orientation��$��Center=��� $��Center=����� *PlaceOrientation+�� $��Place Z Offset��$��Center=��� $��Center=����� *PlaceZOffset+�� $��Gripper Open Offset��$��Center=��� $��Center=����� *GripperOpenOffset+�� $��
Test Place��$	��100��$
��Left=�$��0,20,0,0q�$��30���� $��Location Select��$��2��$��5q�.��� $��5q� � RowDefinitions �� $
��Auto � �� $
��Auto ��� $��* �.+��� $��Tray Pocket��$	��Top=�$��0,2,10,0q�$��0���� -   $��cmbTray��$	��100��$��25��$	��Top=�$
��Left=�$��1��	 �� SelectedValue	 �� *
TrayPocket+�� $��Option��$��3��$��5q�.���� $��5q�.+��� $��Place To Output 2��
 d� 	IsChecked
 �� *PlaceOutput2+�� $��	Dust Blow��
 �� *
DustBlow+�� $��Extra Action��
 �� *ExtraAction+�� $��Eject Board After Place��
 �� *EjectBoardAfterPlace+�� $��Use Post Vision��
 �� *UsePostVision+�� $��Reverse��
 �� *	Reverse+