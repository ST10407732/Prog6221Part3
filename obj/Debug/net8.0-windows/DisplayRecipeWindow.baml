   M S B A M L   `   `   `  ����P  LRecipeAppWPF_PoePart3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RecipeAppWPF_PoePart3RecipeAppWPF_PoePart3  5   	   /    )RecipeAppWPF_PoePart3.DisplayRecipeWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RecipeAppWPF_PoePart3     5   	     � Title$  Display Recipe��5   	   $	��450��6    $	��800��6-   .��5	      � 
�������.+�5
   
   �� $��Display Recipe��6   $��Center=�5      $	��Top=�5      $��19(�5      $��0,10,0,0q�5      �� 5   
   $��20q�6   .+�5      �� $��Select a Recipe:��6   $
��Bold"�60   $��0 0 0 10q�6B   �� 5      -   5         ��Name$ RecipeListBox��5       �� DisplayMemberPath$ 
RecipeName��6-   $	��150��6L   $��0 0 0 10q�6Y   �� 5      -   5        $��Display Recipe��5      $��0 0 0 10q�6P   $
��Left=�6b   �� 5      
���   �$��1q�6)   $	��150��6=   $
��0 10q�6J   ._�5      �� $
��Auto=�6   .��5      �� -   5         ��Name$ RecipeDetailsTextBlock��5       $��10q�6@   5      5      �� 5      -   5        $��Back to Menu��5      $
��Left=�6K   5      5      5      