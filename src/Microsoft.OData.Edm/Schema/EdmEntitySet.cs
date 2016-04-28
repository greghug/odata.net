//---------------------------------------------------------------------
// <copyright file="EdmEntitySet.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

namespace Microsoft.OData.Edm
{
    using Microsoft.OData.Edm.Vocabularies;

    /// <summary>
    /// Represents an EDM entity set.
    /// </summary>
    public class EdmEntitySet : EdmEntitySetBase, IEdmEntitySet
    {
        private readonly IEdmEntityContainer container;
        private readonly IEdmCollectionType type;
        private IEdmPathExpression path;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmEntitySet"/> class.
        /// </summary>
        /// <param name="container">An <see cref="IEdmEntityContainer"/> containing this entity set.</param>
        /// <param name="name">Name of the entity set.</param>
        /// <param name="elementType">The entity type of the elements in this entity set.</param>
        public EdmEntitySet(IEdmEntityContainer container, string name, IEdmEntityType elementType)
            : base(name, elementType)
        {
            EdmUtil.CheckArgumentNull(container, "container");

            this.container = container;
            this.type = new EdmCollectionType(new EdmEntityTypeReference(elementType, false));
            this.path = new EdmPathExpression(this.container.FullName() + "." + this.Name);
        }

        /// <summary>
        /// Gets the kind of element of this container element.
        /// </summary>
        public EdmContainerElementKind ContainerElementKind
        {
            get { return EdmContainerElementKind.EntitySet; }
        }

        /// <summary>
        /// Gets the container of this entity set.
        /// </summary>
        public IEdmEntityContainer Container
        {
            get { return this.container; }
        }

        /// <summary>
        /// Gets the type of this entity set.
        /// </summary>
        public override IEdmType Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// Gets the path that a navigation property targets. 
        /// </summary>
        public override IEdmPathExpression Path
        {
            get { return this.path; }
        }
    }
}