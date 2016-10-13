﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using WebBlocks.Utilities.WebBlocks;

namespace WebBlocks.Utilities.Umbraco
{
    /// <summary>
    /// Provider for DynamicPublishedContent
    /// This will provide published and unpublished content depending on whether in the builder or not
    /// </summary>
    public class PublishedContentProvider
    {
        /// <summary>
        /// Loads a DynamicPublishedContent instance for a given node id.
        /// If WebBlocksUtility.IsInBuilder is true, it will return the unpublished content version
        /// </summary>
        /// <param name="nodeId">The node id of the node</param>
        /// <returns>DynamicPublishedContent instance for a given node id</returns>
        public static DynamicPublishedContent Load(int nodeId)
        {
            ContextHelper.EnsureHttpContext();
            IPublishedContent content = WebBlocksUtility.IsInBuilder
                                            ? new ContentWrapper(nodeId)
                                            : (new UmbracoHelper(UmbracoContext.Current)).TypedContent(nodeId);

            return content != null ? new DynamicPublishedContent(content) : null;
        }

        /// <summary>
        /// Loads a DynamicPublishedContent instance for a given node id.
        /// If WebBlocksUtility.IsInBuilder is true, it will return the unpublished content version
        /// </summary>
        /// <param name="nodeId">The node id of the node</param>
        /// <returns>DynamicPublishedContent instance for a given node id</returns>
        public static DynamicPublishedContent Load(string nodeId)
        {
            return Load(int.Parse(nodeId));
        }

        /// <summary>
        /// Loads a DynamicPublishedContent instance for a given node guid.
        /// If WebBlocksUtility.IsInBuilder is true, it will return the unpublished content version
        /// </summary>
        /// <param name="guid">The node id of the node</param>
        /// <returns>DynamicPublishedContent instance for a given node id</returns>
        public static DynamicPublishedContent LoadByGuid(string guid)
        {
            ContextHelper.EnsureHttpContext();
            IPublishedContent content = WebBlocksUtility.IsInBuilder
                                            ? new ContentWrapper(Guid.Parse(guid))
                                            : (new UmbracoHelper(UmbracoContext.Current)).TypedContent(Guid.Parse(guid));

            return content != null ? new DynamicPublishedContent(content) : null;
        }
    }
}