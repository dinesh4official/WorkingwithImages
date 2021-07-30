using System;
using System.Reflection;
using System.Windows.Input;
using Regenesys.Views;
using RegenesysCore.Constants;
using Xamarin.Forms;

namespace Regenesys.Helper.Behavior
{
	public class BasePageBehavior : BehaviorBase<BasePage>
	{
		#region Fields

		Delegate eventHandler;

		#endregion

		#region Bindable Properties

		public static readonly BindableProperty EventNameProperty = BindableProperty.Create(nameof(EventName), typeof(string), typeof(BasePageBehavior), null, propertyChanged: OnEventNameChanged);
		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(BasePageBehavior), null);

		#endregion

		#region Constructor

		public BasePageBehavior()
		{

		}

		#endregion

		#region Properties

		public string EventName
		{
			get { return (string)GetValue(EventNameProperty); }
			set { SetValue(EventNameProperty, value); }
		}

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}


		#endregion

		#region Override Methods

		protected override void OnAttachedTo(BasePage bindable)
		{
			base.OnAttachedTo(bindable);
			RegisterEvent(EventName);
		}

		protected override void OnDetachingFrom(BasePage bindable)
		{
			base.OnDetachingFrom(bindable);
			DeregisterEvent(EventName);
		}

		#endregion

		#region Callback Methods

		static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var behavior = (BasePageBehavior)bindable;
			if (behavior.AssociatedObject == null) { return; }

			behavior.DeregisterEvent((string)oldValue);
			behavior.RegisterEvent((string)newValue);
		}

		#endregion

		#region Private Methods

		private void RegisterEvent(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) { return; }

			EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
			if (eventInfo == null)
			{
				throw new ArgumentException(string.Format(AppConstants.BehaviorRegisterError, EventName));
			}

			MethodInfo methodInfo = typeof(BasePageBehavior).GetTypeInfo().GetDeclaredMethod(AppConstants.OnEvent);
			eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
			eventInfo.AddEventHandler(AssociatedObject, eventHandler);
		}

		private void DeregisterEvent(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) { return; }

			if (eventHandler == null) { return; }

			EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
			if (eventInfo == null)
			{
				throw new ArgumentException(string.Format(AppConstants.BehaviorDeRegisterError, EventName));
			}

			eventInfo.RemoveEventHandler(AssociatedObject, eventHandler);
			eventHandler = null;
		}

		private void OnEvent(object sender, object eventArgs)
		{
			if (Command == null) { return; }

			if (Command.CanExecute(eventArgs))
			{
				Command.Execute(eventArgs);
			}
		}

		#endregion
	}
}