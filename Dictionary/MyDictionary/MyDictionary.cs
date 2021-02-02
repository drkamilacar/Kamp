using System;
using System.Collections.Generic;
using System.Text;

namespace MyDictionary
{
    class MyDictionary<TKey, TValue>
    {
        TKey[] _keyArray;
        TKey[] _tempKeyArray;
        TValue[] _valueArray;
        TValue[] _tempValueArray;

        public MyDictionary()
        {
            _keyArray = new TKey[0];
            _valueArray = new TValue[0];
        }
        public void Add(TKey tKey, TValue tValue)
        {
            _tempKeyArray = _keyArray;
            _tempValueArray = _valueArray;
            _keyArray = new TKey[_keyArray.Length + 1];
            _valueArray = new TValue[_valueArray.Length + 1];
            for (int i = 0; i < _tempKeyArray.Length; i++)
            {
                _keyArray[i] = _tempKeyArray[i];
                _valueArray[i] = _tempValueArray[i];
            }
            _keyArray[_keyArray.Length - 1] = tKey;
            _valueArray[_keyArray.Length - 1] = tValue;
        }
    }
}
