﻿using System;
using System.Collections;

namespace izci
{
    public class RingList<T>
    {
        IEnumerator enumerator;

        public RingList(T[] array)
        {
            enumerator = array.GetEnumerator();
        }

        public T Next()
        {
            if (!enumerator.MoveNext())
            {
                enumerator.Reset();
                enumerator.MoveNext();
            }

            return (T)enumerator.Current;
        }
    }
}