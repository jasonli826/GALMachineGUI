   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GALNewGUI.ProductGALNewGUI.Product  #    GALNewGUI.Product.InputDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:GALNewGUI.Product       � Title$  InputDialog�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 	Resources  �� MergedDictionaries �� Source��  �� $ ../Resources/Themes.xaml?�%    .���� 	 �� CornerRadius$	 10��
 �� Padding$
 2q� J� SnapsToDevicePixels . ����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ #a1c4fd�� � Offset$	 0.0Q�� $ #c2e9fb��$	 1.0Q�� $ Yellow��$	 1.0Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ Black��   	Direction$	 270Q�   
BlurRadius$ 15Q�   ShadowDepth$ 3Q�   Opacity$	 0.3Q�._�� $��20q�  �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  '��       �� " ��.���  � ��$ 5q���  � ��$	 8,4q���  � ��$ SemiBold"���  � ��
 �������  � �� �#4f46e5��  � �� �#4338ca��  � ��$ 1q���  �@�Cursor$
 Hand����  � �� �� " ��.R��� #��z��#��z��#��z��$	 6��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �#6366f1P�  � �� . . ���  � �� �#3730a3 � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��lblQuestion��$��0��$$��🌈 Please Enter Product Name��$��16(�$
��Bold"����#1e293b$��0,0,0,10q��� -   $��	txtAnswer��$��1��$	��280��$��35��$��14(�$��6q�
�������
���   ����#94a3b8$��1q�$��0,0,0,10q�$��Center=��� $��2�� �� Orientation$ 
Horizontal=�$��Right=�.+��� -   $��btnDialogOk�� �� 	IsDefault . $��✔ OK��   ModernButton#��[  $��Center=�$��5q��� -     �� IsCancel  . $��
✖ Cancel��  
stopButton#��[ $��Center=�$��5q�