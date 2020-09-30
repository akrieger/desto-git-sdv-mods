﻿namespace GiftDecline
{
	using Common;
	using StardewModdingAPI;

	/// <summary>Methods to alter the save game data.</summary>
	internal static class MultiplayerHelper
	{
		private static IMultiplayerHelper helper;

		/// <summary>UniqueID of the mod manifest.</summary>
		public static string ModId { get; set; }

		/// <summary>Initialize the helper.</summary>
		/// <param name="helper">Instance to use for sending messages.</param>
		public static void Init(IMultiplayerHelper helper)
		{
			MultiplayerHelper.helper = helper;
			ModId = helper.ModID;
		}

		/// <summary>Send a message to all connected peers.</summary>
		/// <typeparam name="T">Generic type parameter.</typeparam>
		/// <param name="message">Message to send. Can be plain text or even class objects.</param>
		/// <param name="type">Identifier for the message type.</param>
		public static void SendMessage<T>(T message, string type)
		{
			if (!Context.IsMultiplayer) return;

			Logger.Trace("Sending message to peers. Type = " + type);
			helper.SendMessage(message, type, new[] { ModId });
		}
	}
}