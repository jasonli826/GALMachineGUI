   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GALNewGUI.ControlsGALNewGUI.Controls  ,    &GALNewGUI.Controls.ModernMessageDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2local clr-namespace:GALNewGUI.Controls     -   $	��200��$	��400��
�������.����   �� CornerRadius$  15�����#DDDDDD$��1q� �� Padding$ 20q����� *BackgroundColor+._��  � RowDefinitions �� $��* ��� $
��Auto �.+���  �� Orientation$ Vertical=�$��Center=�$��Center=�.+��� -    ��Name$ 	TitleText��$��20(�$
��Bold"�
������� �� TextAlignment$ Center=�$��0,0,0,10q��� -   $ MessageText��$��16(�
�������$ Center=�$
��Wrap=��� $��1��$ 
Horizontal=�$��Center=�$��0,20,0,0q�.+��� -    ��Name$ OkPanel��$ 
Horizontal=�$y�	Collapsed=�.+��� -   $��OK��$��80��$��5q��� -   $ 
YesNoPanel��$ 
Horizontal=�$y�	Collapsed=�.+��� -   $	��Yes��$��80��$��5q��� -   $��No��$��80��$��5q�