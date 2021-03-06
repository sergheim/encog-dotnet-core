//
// Encog(tm) Core v3.2 - .Net Version
// http://www.heatonresearch.com/encog/
//
// Copyright 2008-2014 Heaton Research, Inc.
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
namespace Encog.Neural.PNN
{
    /// <summary>
    /// The output mode that will be used by the PNN.
    /// </summary>
    ///
    public enum PNNOutputMode
    {
        /// <summary>
        /// Unsupervised training will make use of autoassociation. No "ideal" values
        /// should be provided for training. Input and output neuron counts must
        /// match.
        /// </summary>
        ///
        Unsupervised,

        /// <summary>
        /// Regression is where the neural network performs as a function. Input is
        /// supplied, and output is returned. The output is a numeric value.
        /// </summary>
        ///
        Regression,

        /// <summary>
        /// Classification attempts to classify the input into a number of predefined
        /// classes. The class is stored in the ideal as a single "double" value,
        /// though it is really treated as an integer that represents class
        /// membership. The number of output neurons should match the number of
        /// classes. Classes are indexed beginning at 0.
        /// </summary>
        ///
        Classification
    }
}
