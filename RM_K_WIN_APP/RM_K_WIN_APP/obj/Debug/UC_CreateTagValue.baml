   M S B A M L   `   `   `  ����G  CRM_K_WIN_APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RM_K_WIN_APPRM_K_WIN_APP  5      $    RM_K_WIN_APP.UC_CreateTagValue   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:RM_K_WIN_APP     5      $	��540��5   7   $	��800��6D   .��5	      �� 
�������  �� Orientation$  Vertical=�6*   .+�5
   
   �� $��36��6   $	��171��6   $��LeftToRight=�6(   $
��Left=�6D   $��
20,20,0,20q�6_   $��20(�6s   $��Heavy"�6�   .��6�   Add Tag Value:-6�   �� 5   
   $  
Horizontal=�6   .+�5      �� 
�������$��20(�6+   $
��Bold"�69   $��
25,20,10,5q�6K   $��1q�6_   
���   �$	��168��6�   .��6�   Resource Name6�   �� 5      -   5         ��Name$ cmBxResourceName��5      $��35��61   $	��300��6=   
�������$��Bottom=�6a   $��10,5,5,5q�6|   $��1q�6�   
���   � �� DisplayMemberPath$ ResourceName��5       �� SelectedValuePath$ 
ResourceId��68   
���   �6W   5      �� 5   
   $  
Horizontal=�6   .+�5      �� 
�������$��20(�6+   $
��Bold"�69   $��
25,20,10,5q�6K   $��1q�6_   
���   �$	��167��6�   .��6�   
Tag Name6�   �� 5      -   5        $ cmBxTagName��5      $��35��6,   $	��300��68   
�������$��Bottom=�6\   $��10,5,5,5q�6w   $��1q�6�   
���   �$ TagName��5      $ TagId��63   
���   �6b   5      �� 5   
   -   5         ��Name$ TagValuePanel��5      $  
Horizontal=�6,   $y�	Collapsed=�6E   .+�5      �� -   5         ��Name$ labelTagName��5      
�������$��20(�6A   $
��Bold"�6O   $��
25,20,10,5q�6a   $��1q�6u   
���   �$	��167��6�   .��6�   	Tag Value6�   �� 5      -   5         ��Name$ 
textTagVal��5      $��35��6*   $	��200��66   
�������$��Bottom=�6Z   $��10,5,5,5q�6u   $��1q�6�   
���   �
���   �5   -   �� 5      -   5        $ tagValueUOM��5      $��30��6)   $��50��65   $	��5,5q�6@   .��6N   	Tag Value6Y   5      �� 5   
   -   5         ��Name$ btnAddTagValue��5      $	��129��6)   $��40��65   $
��Left=�6A   $��
282,10,0,5q�6\   .��6�   Add Tag Value6�   �� 5   
   -   5        $ 	btnImport��5      $��Import Tag File��6$   $��244,50,350,0q�6>   $��62��6T    J� RenderTransformOrigin$ 
0.38,2.129&�6`   ���	#FF37887B6�   5      5      