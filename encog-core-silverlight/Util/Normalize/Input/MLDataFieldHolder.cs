//
// Encog(tm) Core v3.0 - .Net Version
// http://www.heatonresearch.com/encog/
//
// Copyright 2008-2011 Heaton Research, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//   
// For more information on Heaton Research copyrights, licenses 
// and trademarks visit:
// http://www.heatonresearch.com/copyright
//
using System;
using System.Collections.Generic;
using Encog.ML.Data;

namespace Encog.Util.Normalize.Input
{
    /// <summary>
    /// Simple holder class used internally for Encog.
    /// Used as a holder for a:
    /// 
    ///  NeuralDataPair
    ///  Enumeration
    ///  InputFieldNeuralDataSet
    /// </summary>
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public class MLDataFieldHolder
    {
        /// <summary>
        /// A field.
        /// </summary>
        private readonly InputFieldMLDataSet _field;

        /// <summary>
        /// An iterator.
        /// </summary>
        private readonly IEnumerator<IMLDataPair> _iterator;

        /// <summary>
        /// A neural data pair.
        /// </summary>
        private IMLDataPair _pair;

        /// <summary>
        /// Construct the class.
        /// </summary>
        /// <param name="iterator">An iterator.</param>
        /// <param name="field">A field.</param>
        public MLDataFieldHolder(IEnumerator<IMLDataPair> iterator,
                                     InputFieldMLDataSet field)
        {
            _iterator = iterator;
            _field = field;
        }

        /// <summary>
        /// The field.
        /// </summary>
        public InputFieldMLDataSet Field
        {
            get { return _field; }
        }

        /// <summary>
        /// The pair.
        /// </summary>
        public IMLDataPair Pair
        {
            get { return _pair; }
            set { _pair = value; }
        }

        /// <summary>
        /// Get the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<IMLDataPair> GetEnumerator()
        {
            return _iterator;
        }

        /// <summary>
        /// Obtain the next pair.
        /// </summary>
        public void ObtainPair()
        {
            _iterator.MoveNext();
            _pair = _iterator.Current;
        }
    }
}