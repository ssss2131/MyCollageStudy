   M S B A M L   `   `   `  ????D  @MyTodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MyTodoApp.Views.DialogMyTodoApp.Views.Dialog  5      .    (MyTodoApp.Views.Dialog.AddMemoDialogView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:MyTodoApp.Views.Dialog     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .??5
      ?   ? RowDefinitions  5   
   ?? 5      $
??Auto ?6   ?? 5      ?? 5      $
??Auto ?6   .+?5   
   ?? $??30(?6   $??50q?6"   $
??Bold"?6.   $??新增备忘录??6@   ]? 5   
   $??1??6   $??False??6!   .+?5      ?? $	??Top=?6   $	??400??6H   $??50 10q?6T   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 输入待办标题??6c   ??6+   ?? *Model.Title+6c   ?? 5      $	??Top=?6   $	??400??6J   $??50 10q?6V   $ 输入待办内容??6e    ?? AcceptsReturn$
 True??5       ?? TextWrapping$
 Wrap=?6-   $??60??6A   ??5   +   ?? *Model.Content+5   A   5      ?? 5   
   $??2??6    ?? Orientation$ 
Horizontal=?6"   $??Center=?6;   .+?5      ?? $??20q?6   $??确 认??6A   ??6!   ?? *SaveCommand+6A   ?? 5      $??取消??6       MaterialDesignOutlinedButton#??[  6E   ??6#   ?? *CancelCommand+6E   5      5      5      