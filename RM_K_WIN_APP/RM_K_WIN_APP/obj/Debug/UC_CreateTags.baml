   M S B A M L   `   `   `  ����G  CRM_K_WIN_APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RM_K_WIN_APPRM_K_WIN_APP  5           RM_K_WIN_APP.UC_CreateTags   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:RM_K_WIN_APP     5      -   5          >�Name$  	UC_TagReg��5      $	��540��5      $	��800��6,   .��5      �� 
������� �� Orientation$ Vertical=�6*   .+�5	   
   �� $��36��6   $	��160��6   $��LeftToRight=�6(   $
��Left=�6D   $��
20,20,0,20q�6_   $��20(�6s   $��Heavy"�6�   .��6�   
Add Tags:-6�   �� 5
   
   $ 
Horizontal=�6   .+�5      �� 
�������$��20(�6+   $
��Bold"�69   $��
25,20,10,5q�6K   $��1q�6_   
���   �$	��117��6�   .��6�   
Resource6�   �� 5      -   5         ��Name$ cmBxResource��5      $��35��6-   $	��300��69   
�������$��Bottom=�6]   $��10,5,5,5q�6x   $��1q�6�   
���   � �� DisplayMemberPath$ ResourceDisplayName��6�    �� SelectedValuePath$ 
ResourceId��5      
���   �6K   5      �� 5   
   $ 
Horizontal=�6   .+�5      �� 
�������$��20(�6+   $
��Bold"�69   $��
25,20,10,5q�6K   $��1q�6_   
���   �$	��117��6�   .��6�   
Tag Name6�   �� 5      -   5        $ cmBxTagName��5      $��35��6,   $	��300��68   
�������$��Bottom=�6\   $��10,5,5,5q�6w   $��1q�6�   
���   �$ TagName��6�   $ TagName��6�   
���   �5   \   5      �� 5   
   $ 
Horizontal=�6   .+�5      �� 
�������$��20(�6+   $
��Bold"�69   $��
25,20,10,5q�6K   $��1q�6_   
���   �$	��115��6�   .��6�   	Tag UOM6�   �� 5      -   5         ��Name$ txtBxTagUOM��5      $��35��6+   $	��300��67   
�������$��Bottom=�6[   $��10,5,5,5q�6v   $��1q�6�   
���   �
���   �6�   5      �� 5   
   $ 
Horizontal=�6   .+�5      �� 
�������$��20(�6+   $
��Bold"�69   $��
25,20,10,5q�6K   $��1q�6_   
���   �$	��115��6�   .��6�   	Add Tag6�   �� 5      -   5         ��Name$ 	btnAddTag��5      $	��100��6(   $��40��64   $
��Left=�6@   $��	10,10,5,5q�6[   .��6�   YES6�   �� 5      -   5        $ btnCancelEntry��5      $	��100��6-   $��40��69   $
��Left=�6E   $��	10,10,5,5q�6`   .��6�   NO6�   5      5      5      