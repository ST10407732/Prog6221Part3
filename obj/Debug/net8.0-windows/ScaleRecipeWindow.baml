   M S B A M L   `   `   `  ����P  LRecipeAppWPF_PoePart3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RecipeAppWPF_PoePart3RecipeAppWPF_PoePart3  5   	   -    'RecipeAppWPF_PoePart3.ScaleRecipeWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RecipeAppWPF_PoePart3     5   	     � Title$  ScaleRecipeWindow��5   	   $	��450��6#   $	��800��60   .��5	      � 
�������.+�5
   
   �� $��Scale Recipe��6   $��Center=�5      $	��Top=�5      $��19(�5      $��0,10,0,0q�5      �� 5   
   $��20q�6   .+�5      �� $��Enter Recipe Name:��6   $
��Bold"�62   $��0 0 0 10q�6D   �� 5      -   5         ��Name$ RecipeNameTextBox��5      $��0 0 0 10q�61   $	��200��6C   �� 5      $>��8Enter Scaling Factor (e.g., 0.5 for half, 2 for double):��6   $
��Bold"�6X   $��	0 10 0 10q�6j   �� 5      -   5        $ ScalingFactorTextBox��5      $��0 0 0 10q�64   $	��200��6F   �� 5      -   5        $��Scale Recipe��5      $��	0 10 0 10q�6L   $
��Left=�6_   �� 5      
���   �$��1q�6)   $	��300��6=   $
��0 10q�6J   ._�5      �� $
��Auto=�6   .��5      �� -   5         ��Name$" ScaledRecipeDetailsTextBlock��5       $��10q�6F   $
��Wrap=�6R   $��14(�6f   5      5      �� 5      -   5        $��Back to Menu��5      $
��Left=�6G   $
��0 10q�6b   5      5      5      