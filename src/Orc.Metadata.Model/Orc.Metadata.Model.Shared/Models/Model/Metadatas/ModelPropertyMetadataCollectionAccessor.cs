﻿// 
// The MIT License (MIT)
// 
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

namespace Orc.Metadata.Model.Models.Model.Metadatas
{
    using System.Collections.Generic;

    using Catel;

    using Orc.Metadata.Model.Models.Interfaces;
    using Orc.Metadata.Model.Models.Metadatas;

    /// <summary>Provides access to the <see cref="IModelPropertyMetadataCollection" />.</summary>
    public class ModelPropertyMetadataCollectionAccessor
        : MetadataAggregator<IModelPropertyMetadataCollection>
    {
        #region Fields

        private IModelPropertyMetadataCollection _propertyMetadataCollection;

        #endregion



        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ModelPropertyMetadataCollectionAccessor" />
        ///     class.
        /// </summary>
        /// <param name="propertyMetadataCollection">The property metadata collection.</param>
        public ModelPropertyMetadataCollectionAccessor(
            IModelPropertyMetadataCollection propertyMetadataCollection)
        {
            Argument.IsNotNull(() => propertyMetadataCollection);

            _propertyMetadataCollection = propertyMetadataCollection;
        }

        #endregion



        #region Properties

        public override string Name => ModelMetadataTypes.PropertyMetadatas;
        public override string DisplayName
        {
            get { return Name; }
            set { }
        }

        #endregion



        #region Methods

        protected override IModelPropertyMetadataCollection AggregateValue(
            object instance,
            IEnumerable<GenericMetadata<IModelPropertyMetadataCollection>> metadatas)
        {
            foreach (var metadata in metadatas)
            {
                var propertyMetadataCollection = metadata.GetTypedValue(instance);

                _propertyMetadataCollection.MergePropertyMetadataCollection(
                    propertyMetadataCollection);
            }

            return _propertyMetadataCollection;
        }

        public override void SetTypedValue(
            object instance, IModelPropertyMetadataCollection value)
        {
            _propertyMetadataCollection = value;
        }

        #endregion
    }
}