   M S B A M L   `   `   `  ����H  DMachineNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MachineNewGUI.ControlsMachineNewGUI.Controls  5      )    #MachineNewGUI.Controls.GripperPlace   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:MachineNewGUI.Controls     5      $
��auto��5      $
��auto��6     � 	Resources  5	       �� 
TargetType �� Property �� Value��%T   '��       �� 5
   
   " ��6   .�5      ��  � ��
 � � �6+   5      5      .��5      �� -   5        $��Gripper��5      $
��Bold"�6    .��5   
   � $��10q�6    � ColumnDefinitions 5      �� 5      $	��180 �6#   �� 5      $	��310 �6#   �� 5      $	��220 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��5q�6)   .+�5      �� $��Description��6   $
��Bold"�6/   �� 5      -   5         ��Name$ txtDesc��5      $��0,5,0,0q�6H   ��6+   �� *Description+6H   5       �� 5#      $��Offsets��6   $��1��6(   $��5q�68   $��Stretch=�6C   $
��Auto��6_   .��5$      �� $��5q�6   .+�5%      A�  A� Columns$ 2��6"    A� Rows$ 2��6.   $��0,0,0,5q�67   .+�5&      �� $��Place Orientation��6$   $��Center=�6=   �� 5'      $��Center=�6E   ��6"   �� *PlaceOrientation+6E   �� 5)      $��Place Z Offset��6$   $��Center=�6:   �� 5*      $��Center=�6A   ��6"   �� *PlaceZOffset+6A   �� 5,      $��Gripper Open Offset��6$   $��Center=�6?   �� 5-      $��Center=�6F   ��6"   �� *GripperOpenOffset+6F   5.      �� 5/      $��
Test Place��6   $	��100��62   $
��Left=�6>   $��0,20,0,0q�6Y   $��30��6k   50      51      �� 54      $��Location Select��6   $��2��60   $��5q�6@   .��55      � $��5q�6    � RowDefinitions 56      �� 57      $
��Auto �6(    59      �� 5:      $
��Auto �6+   �� 5;      $��* �6+   .+�5?      �� $��Tray Pocket��6    $	��Top=�5@      $��0,2,10,0q�5A      $��0��5B      �� 5E      -   5        $��cmbTray��5E      $	��100��5F      $��25��5G      $	��Top=�5H      $
��Left=�5I      $��1��5J      	 �� SelectedValue	 6#   �� *
TrayPocket+5K      5L      �� 5O      $��Option��6   $��3��6'   $��5q�67   .��5P      �� $��5q�6   .+�5Q      �� $��Place To Output 2��6   
 d� 	IsChecked
 6;   �� *PlaceOutput2+�� 5R      $��	Dust Blow��6   
 63   �� *
DustBlow+�� 5S      $��Extra Action��6   
 66   �� *ExtraAction+�� 5T      $��Eject Board After Place��6   
 6A   �� *EjectBoardAfterPlace+�� 5U      $��Use Post Vision��6   
 69   �� *UsePostVision+�� 5V      $��Reverse��6   
 61   �� *	Reverse+5W      5X      5Y      5Z      5[      