   M S B A M L   `   `   `  ����G  CRM_K_WIN_APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RM_K_WIN_APPRM_K_WIN_APP  5   	       RM_K_WIN_APP.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:RM_K_WIN_APP     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��600��5      $
��1080��6'   
�������  � 
ResizeMode$  NoResize=�6G    � WindowStartupLocation$ CenterScreen=�6]    � WindowStyle$
 None=�6�    � 	Resources 5	         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �     �� 5
   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 70Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 ButtonOpenMenu��66   .[�5      �� #��[  6   5      :� 5   
   $	 ButtonBase.Click��6   $
 ButtonCloseMenu��66   .[�5      �� #��[ 6   5      .��5      � ���	#FFDEDEDE.+�5    
   � -   5         �Name$ GridMain��5       $��Center=�6!   $��Center=�6>   $	��540��6Y   $
��1010��6f   $��	70,60,0,0q�6s   .+�5!      �� $��Center=�6   $��Center=�66   .+�5"      �� $��Center=�6   $��Center=�65   $��50(�6P   $
��Bold"�6^   .��6p   	WELCOME6y   5#      5$      � 5%   
   $��60��6   $	��Top=�6   ���	#FF5C99D6 J� Effect 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�5)      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5*      �� -   5         ��Name$ panelWindowMinimize��5*      $ 
Horizontal=�6:   .+�5+      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�6.   $��25��6E   $��25��6Q   $��10q�6\   
�������$��Center=�6�   5,      �� 5-      -   5        $ panelWindowResize��5-      $ 
Horizontal=�68   .+�5.        $ WindowRestore=�6.   $��25��6D   $��25��6P   $��10q�6[   
�������$��Center=�6   5/      �� 50      -   5        $ 
panelClose��50      $ 
Horizontal=�61   .+�51        $ Close=�6.   $��25��6;   $��25��6G   $��10q�6R   
�������$��Center=�6v   52      '  !MaterialDesignThemes.Wpf.PopupBox  53         PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen .  $��10q�6e      PopupContent. 54      �� $	��150��6!   .+�55      �� -   5         ��Name$ btnSettings��55   !   $��Settings��66   6I   �� 56      $��Account��6!   �� 57      $
��Help��6!   �� 58      �� 59      $��Logout��6!   5:      5;      5<      �� 5=      $��Center=�6   $��Center=�65   $��22(�6P   Resource Management6s   5>      � 5?   
   -   5        $ GridMenu��5?      $��70��6!   $
��Left=�6,   ���	#FF31577E 5@        5A      $ 2Q�6#   $ 1Q�62   $ 	#FFAEAEAE��6B   .+�5C      �� .+�5D      � $	��150��6   
������� J� RenderTransformOrigin$ 0.5,0.5&�67   z�5E      V� 5F      .~�5G      �� �� 5H      �� 5I      T� 5J      5K      .+�5M      �� -   5        $ ButtonOpenMenu��5M      $��60��65   $��60��6A   $��5q�6L   $��Right=�6W   $	��Top=�6s    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5N        $
 Menu=�62   $��25��6>   $��25��6I   5O      �� 5P      -   5        $ ButtonCloseMenu��5P      $y�	Collapsed=�66   $��60��6M   $��60��6Y   $��5q�6d   $��Right=�6o   $	��Top=�6�   #��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5Q        $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5R      �� 5T      $��80��6   $��Bottom=�6(   5U      �� 5V      -	   5         ��Name$ ListViewMenu��5V      ���	#FF5C99D6$��Disabled=�6H   .@�5W      �� -
   5         ��Name$ TypePage��5W   #   $��60��65   .��5X      �� $ 
Horizontal=�6%   .+�5Y        $
 Gift=�66   $��25��6C   $��25��6O   $��10q�6Z   �� 5Z      $��Create Types��6(   $��Center=�6<   $��20 10q�6W   5[      5\      �� 5]      -   5        $ 
StatusPage��5]   #   $��60��67   .��5^      �� $ 
Horizontal=�6%   .+�5_        $ Alarm=�66   $��25��6D   $��25��6P   $��10q�6[   �� 5`      $��Create Status��6(   $��Center=�6=   $��20 10q�6X   5a      5b      �� 5c      -   5        $ TagRegistartionPage��5c   #   $��60��6@   .��5d      �� $ 
Horizontal=�6%   .+�5e        $	 Tag=�66   $��25��6A   $��25��6M   $��10q�6X   �� 5f      $��Register Tags��6(   $��Center=�6=   $��20 10q�6Y   5g      5h      �� 5i      -   5        $ ResourceAddPage��5i   #   $��60��6<   .��5j      �� $ 
Horizontal=�6%   .+�5k        $
 Cart=�66   $��25��6C   $��25��6O   $��10q�6Z   �� 5l      $��Create Resource��6(   $��Center=�6?   $��20 10q�6[   5m      5n      �� 5o      -   5        $ TagValuePage��5o   #   $��60��69   .��5p      �� $ 
Horizontal=�6%   .+�5q        $ 
TagOutline=�66   $��25��6I   $��25��6U   $��10q�6`   �� 5r      $��Add Tag Value��6(   $��Center=�6=   $��20 10q�6Y   5s      5t      5u      5v      5w      5x      5y      