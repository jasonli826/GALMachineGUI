   M S B A M L   `   `   `  ���� D  @GALNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GALNewGUI.UtilitiesGALNewGUI.Utilities  #    GALNewGUI.Utilities.IOUtility   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:GALNewGUI.Utilities     -     � Title$  	IOUtility��$
��1600��$
��1000�� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ #007ACC�� � Offset$ 1Q�� $ #FFD500��$ 1Q�� $ #00C9FF��$ 1Q� � 	Resources  �� MergedDictionaries	 �� Source��  �� $	 ../Resources/Themes.xaml?�%    .��]� ��. .+��� 
�������
 �� Padding$
 10q����#DDD$��0,0,0,1q�$	��Top=�._��  � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $��../Images/IO.png��$��38��$��30��$��0���� $��
IO Utility��$��18(�$
��Bold"�   PrimaryColorForLogin#��[  $��Center=�$��10,0,0,0q�$��1���� -    ��Name$ 
btnRefresh��$��Refresh��  ModernButton#��[ $��2���� -   $ 	btnReturn��$��Return��  
stopButton#��[ $��3��$��10,0,0,0q�� $	��Top=�$��	20,0,20,0q�$��50�� �� $��* ��� $��20 ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $ 	Bt_LeftIn��#��[ $��0,0,5,0q�.���� -    ��Name$ 
Img_LeftIn��$��../Images/Back.png��$��24���� -   $ 
Bt_RightIn��#��[ $��5q�.���� -   $ Img_RightIn��$��../Images/Next.png��$��24���� $��2��$ 
Horizontal=�$��Right=�$��Center=�.+��� -   $ 
Bt_LeftOut��#��[ $��0,0,5,0q�.���� -	   $ Img_LeftOut��$��../Images/Back.png��$��24���� -
   $ Bt_RightOut��#��[ $��5q�.���� -   $ Img_RihtOut��$��../Images/Next.png��$��24��� $��10q� �� $��* ��� $��10 ��� $��* �.+�� $��0�� � RowDefinitions �� $
��Auto ��� $��* �.+��� 
������� �� CornerRadius$ 8��$
 10q����#DDD$��1q�$��0��._��� .+��� $��
Input Data��  SectionHeader#��[ $��0,0,0,0q��� -    ��Name$ InputTextBox�� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�$��14(����#F0F8FF���#4285F4$��1q�$��8q� �� TextWrapping$
 Wrap=�$��40���� 
�������$ 8��$��0,10,0,0q�$
 10q����#DDD$��1q�$��1��._��� $
��Auto=�.���� -    ��Name$ 
InputPanel���� $��1�����#CCC$��2��$��Center=�$
��0,10q�� $��2�� �� $
��Auto ��� $��* �.+��� 
�������$ 8��$
 10q����#DDD$��1q�$��0��._��� .+��� $��Output Data��#��[ $��0,0,0,0q��� -   $ OutputTextBox�� . $
 Auto=�$��14(����#FFF7F0���#FB8C00$��1q�$��8q�$
 Wrap=�$��40���� 
�������$ 8��$��0,10,0,0q�$
 10q����#DDD$��1q�$��1��._��� $
��Auto=�.���� -   $ OutputPanel��