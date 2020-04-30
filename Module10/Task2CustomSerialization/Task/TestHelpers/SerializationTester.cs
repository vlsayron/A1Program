﻿using System;
using System.IO;

namespace Task.TestHelpers
{
	public abstract class SerializationTester<TData, TSerializer>
	{
		protected TSerializer Serializer;
        readonly bool _showResult;

        protected SerializationTester(TSerializer serializer, bool showResult = false)
		{
			Serializer = serializer;
			_showResult = showResult;
		}

		public TData SerializeAndDeserialize(TData data)
		{
			var stream = new MemoryStream();

			Console.WriteLine("Start serialization");
			Serialization(data, stream);
			Console.WriteLine("Serialization finished");

			if (_showResult)
			{
				var r = Console.OutputEncoding.GetString(stream.GetBuffer(), 0, (int)stream.Length);
				Console.WriteLine(r);
			}

			stream.Seek(0, SeekOrigin.Begin);
			Console.WriteLine("Start deserialization");
			var result = Deserialization(stream);
			Console.WriteLine("Deserialization finished");

			return result;
		}

		internal abstract TData Deserialization(MemoryStream stream);
		internal abstract void Serialization(TData data, MemoryStream stream);
	}
}
