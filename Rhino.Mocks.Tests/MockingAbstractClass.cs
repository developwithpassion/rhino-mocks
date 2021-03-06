﻿#region license
// Copyright (c) 2005 - 2007 Ayende Rahien (ayende@ayende.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Ayende Rahien nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion


using System;

namespace Rhino.Mocks.Tests
{
	using MbUnit.Framework;

	[TestFixture]
	public class MockingAbstractClass
	{
		private MockRepository mocks;

		[SetUp]
		public void Setup()
		{
			mocks = new MockRepository();
		}

		[TearDown]
		public void Teardown()
		{
			mocks.VerifyAll();
		}

		[Test]
		public void MockAbsPropertyGetter()
		{
			AbsCls ac = (AbsCls)mocks.StrictMock(typeof(AbsCls));
			Expect.Call(ac.AbPropGet).Return("n");
			mocks.ReplayAll();
			Assert.AreEqual("n", ac.AbPropGet);
		}

		[Test]
		public void MockAbsPropertySetter()
		{
			AbsCls ac = (AbsCls)mocks.StrictMock(typeof(AbsCls));
			Expect.Call(ac.AbPropSet = "n");
			mocks.ReplayAll();
			ac.AbPropSet = "n";
		}


		[Test]
		public void MockAbsProp()
		{
			AbsCls ac = (AbsCls)mocks.StrictMock(typeof(AbsCls));
			Expect.Call(ac.AbProp = "n");
			Expect.Call(ac.AbProp).Return("u");
			mocks.ReplayAll();
			ac.AbProp = "n";
			Assert.AreEqual("u", ac.AbProp);
		}

		[Test]
		public void MockAbstractMethod()
		{
			AbsCls ac = (AbsCls)mocks.StrictMock(typeof(AbsCls));
			Expect.Call(ac.Method()).Return(45);
			mocks.ReplayAll();
			Assert.AreEqual(45, ac.Method());
	
		}

		public abstract class AbsCls
		{
			public abstract string AbPropGet { get; }

			public abstract string AbPropSet { set; }

			public abstract string AbProp { get; set; }

			public abstract int Method();

		}
	}
}
