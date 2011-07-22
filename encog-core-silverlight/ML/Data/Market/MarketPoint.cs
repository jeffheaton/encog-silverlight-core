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
using Encog.ML.Data.Temporal;

namespace Encog.ML.Data.Market
{
    /// <summary>
    /// Hold one market datapoint.  This class is based on the TemporalPoint,
    /// however it is designed to take its sequence number from a date.
    /// </summary>
    public class MarketPoint : TemporalPoint
    {
        /// <summary>
        /// When to hold the data from.
        /// </summary>
        private readonly DateTime _when;


        /// <summary>
        /// Construct a MarketPoint with the specified date and size.
        /// </summary>
        /// <param name="when">When is this data from.</param>
        /// <param name="size">What is the size of the data.</param>
        public MarketPoint(DateTime when, int size)
            : base(size)
        {
            _when = when;
        }

        /// <summary>
        /// When is this point from.
        /// </summary>
        public DateTime When
        {
            get { return _when; }
        }
    }
}