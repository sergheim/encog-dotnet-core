﻿//
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
using System.Linq;
using System.Text;
using Encog.ML.Data;
using Encog.Neural.Networks;
using Encog.Neural.Flat;
using Encog.Util;

namespace Encog.MathUtil.Matrices.Hessian
{
    /// <summary>
    /// Some basic code used to calculate Hessian matrixes.
    /// </summary>
    public abstract class BasicHessian: IComputeHessian
    {
        /// <summary>
        /// The training data that provides the ideal values.
        /// </summary>
        protected IMLDataSet training;

        /// <summary>
        /// The neural network that we would like to train.
        /// </summary>
        protected BasicNetwork network;


        /// <summary>
        /// The sum of square error.
        /// </summary>
        protected double sse;

        /// <summary>
        /// The gradients of the Hessian.
        /// </summary>
        protected double[] gradients;

        /// <summary>
        /// The Hessian matrix.
        /// </summary>
        protected Matrix hessianMatrix;

        /// <summary>
        /// The Hessian 2d array.
        /// </summary>
        protected double[][] hessian;

        /// <summary>
        /// The derivatives.
        /// </summary>
        protected double[] derivative;

        /// <summary>
        /// The flat network.
        /// </summary>
        protected FlatNetwork flat;

        /// <inheritdoc/>
        public virtual void Init(BasicNetwork theNetwork, IMLDataSet theTraining)
        {

            int weightCount = theNetwork.Structure.Flat.Weights.Length;
            this.flat = theNetwork.Flat;
            this.training = theTraining;
            this.network = theNetwork;
            this.gradients = new double[weightCount];
            this.hessianMatrix = new Matrix(weightCount, weightCount);
            this.hessian = this.hessianMatrix.Data;
            this.derivative = new double[weightCount];
        }

        /// <inheritdoc/>
        public double[] Gradients
        {
            get
            {
                return gradients;
            }
        }

        /// <inheritdoc/>
        public Matrix HessianMatrix
        {
            get
            {
                return hessianMatrix;
            }
        }

        /// <inheritdoc/>
        public double[][] Hessian
        {
            get
            {
                return hessian;
            }
        }

        /// <inheritdoc/>
        public void Clear()
        {
            EngineArray.Fill(this.gradients, 0);
            this.hessianMatrix.Clear();
        }

        /// <inheritdoc/>
        public double SSE
        {
            get
            {
                return sse;
            }
        }

        /// <summary>
        /// Update the Hessian, sum's with what is in the Hessian already.  Call clear to clear out old Hessian.
        /// </summary>
        /// <param name="d">The first derivatives to update with.</param>
        public void UpdateHessian(double[] d)
        {
            // update the hessian
            int weightCount = this.network.Flat.Weights.Length;
            for (int i = 0; i < weightCount; i++)
            {
                for (int j = 0; j < weightCount; j++)
                {
                    this.hessian[i][j] += 2 * d[i] * d[j];
                }
            }
        }


        /// <inheritdoc/>
        public abstract void Compute();
        
    }
}