   M S B A M L   `   `   `  ����H  DMachineNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MachineNewGUI.ProductMachineNewGUI.Product  5   	   '    !MachineNewGUI.Product.InputDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MachineNewGUI.Product     5   	     � Title$  InputDialog��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6<    � 
ResizeMode$ NoResize=�6a    � WindowStyle$
 None=�6w    � AllowsTransparency . 
������  � 	Resources 5	       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Resources/Themes.xaml?�6%   %    5      .��5      �� 	 �� CornerRadius$	 10��6   
 �� Padding$
 2q�6    J� SnapsToDevicePixels . ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #a1c4fd��6    � Offset$	 0.0Q�6/   � 5      $ #c2e9fb��6   $	 1.0Q�6/   � 5      $ Yellow��6   $	 1.0Q�6/   5       J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6      	Direction$	 270Q�6-      
BlurRadius$ 15Q�6=      ShadowDepth$ 3Q�6M      Opacity$	 0.3Q�6]   ._�5   
   � $��20q�6    5       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%  '��       �� 5       " ��6   .�5!      ��  � ��$ 5q�6/   �� 5"       � ��$	 8,4q�60   �� 5#       � ��$ SemiBold"�63   �� 5$       � ��
 �����63   �� 5%       � �� �#4f46e563   �� 5&       � �� �#4338ca64   �� 5'       � ��$ 1q�68   �� 5(       �@�Cursor$
 Hand��6/   �� 5)       � �� 5*      �� 5+      " ��6.   .R�5,   "   �� #��z��6)   #��z��5-   )   #��z��5.   )   $	 6��5/   )   ._�50   &   �� $��Center=�67   $��Center=�6T   51   #   52      54       55      P� 56       �@J�IsMouseOver . . �57      ��  � �� �#6366f16;   58      P� 59       � �� . . �5:      ��  � �� �#3730a36;   5;      5=      5>       � RowDefinitions 5@      �� 5A      $
��Auto �6    �� 5B      $
��Auto �6    �� 5C      $
��Auto �6    .+�5F      �� -   5        $��lblQuestion��5F      $��0��5G      $$��🌈 Please Enter Product Name��5H      $��16(�5I      $
��Bold"�5J      ���#1e293b$��0,0,0,10q�5L      �� 5N      -   5        $��	txtAnswer��5N      $��1��5O      $	��280��5P      $��35��5Q      $��14(�5R      $��6q�5S      
�������
��� � ����#94a3b8$��1q�5W      $��0,0,0,10q�5X      $��Center=�5Y      �� 5[      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   .+�5\      �� -   5        $��btnDialogOk��5\       �� 	IsDefault . $��✔ OK��6W      ModernButton#��[  6g   $��Center=�6�   $��5q�6�   �� 5]      -   5          �� IsCancel  . $��
✖ Cancel��5]   )     
stopButton#��[ 6<   $��Center=�6`   $��5q�6}   6�   5^      5_      5`      5a      