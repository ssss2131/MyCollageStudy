   M S B A M L   `   `   `  ???? D  @MyTodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MyTodoApp.ViewsMyTodoApp.Views  I)clr-namespace:MyTodoApp.Common.ConvertersMyTodoApp.Common.Converters      MyTodoApp.Views.MemoView   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  )localclr-namespace:MyTodoApp.Views  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  2cv)clr-namespace:MyTodoApp.Common.Converters    ? 	Resources  0   *MyTodoApp.Common.Converters.IntToConverter   IntToVisibility??%   &	          .??)  #MaterialDesignThemes.Wpf.DialogHost  .??)  #MaterialDesignThemes.Wpf.DrawerHost     IsRightDrawerOpen ?? *IsRightDrawerOpen+   RightDrawerContent ]? $	??300??$??False??.+??? $??添加待办??$??10 15q?$??30(?$
??Bold"?$	??Top=??? $??10 30q?)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入待办概要??$	??Top=????? *CurrentDto.Title+?? $??10 30q?$ 请输入待办内容??$	??Top=????? *CurrentDto.Content+?? $??添加到备忘录??$	??Top=?$??更新?????? *ExecuteCommand+.???  ? RowDefinitions ?? $
??auto ??? .+???  ?? Orientation$ 
Horizontal=?$??15,0,0,0q?$??0??.+??? $	??250??$??Center=?$ 查找备忘录事项...??.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True?????? *Search+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?.??	 J? InputBindings	 ?? 

 ?? Key$
 Enter?? ?? CommandParameter$ 查询?? ?? Command ?? *ExecuteCommand+.???? $??0??$
??10,5q?$??Right=?
??? ? ?$??
+备忘录??$??新增?????? *ExecuteCommand+?? $??1??$??Center=?y??? *MemoDtos.Count+ ?? 	Converter# [  .+??? $??../Images/wind.png??$	??120??$	??120???? $??Center=?$
??0 10q?$??18(?$
??Bold"?$<??6尝试添加一些备忘事项，以便在此处查看???? $??1??.???? $??1??$??Center=????? *
MemoDtos+???? .R?? ???? .R??  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension     Kind$ ExpandIn=?.??? $	??220??$	??180??$	??250??$??15q?
?????_?*	  $Microsoft.Xaml.Behaviors.Interaction 	  Triggers +
  %Microsoft.Xaml.Behaviors.EventTrigger
   
  	EventName$ MouseLeftButtonUp??*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter ??    Command ?? *DataContext.SelectedCommand+ ?? RelativeSource ??  ?? Mode$ FindAncestor=? ?? AncestorType ItemsControl ?? $
??auto ??? .+?'  !MaterialDesignThemes.Wpf.PopupBox   K? ZIndex$ 1??$??Right=?   PopupContent. ?? $??删除?????? ???? *DataContext.DeleteCommand+ ?? $ FindAncestor=? ItemsControl??  ?? CornerRadius$ 30??$??2????  ?? Padding$
 10,5q?$
??Bold"?$??20(????? *Title+?? $
 10,5q?$??1?????? *	Content+?? $
}?true??$??2??.+??? 
 ?? Top$ 10??$	 100?? ?? Right$	 -50??$	??120??$	??120?????#FFFF J? Opacity$	 0.1Q??? $ 80??$	 100??$	 -30??$	??120??$	??120?????#FFFF$	 0.1Q?