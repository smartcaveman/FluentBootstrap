﻿using FluentBootstrap.Html;
using FluentBootstrap.Labels;
using FluentBootstrap.ListGroups;
using FluentBootstrap.MediaObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IHeadingCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class HeadingWrapper<THelper> : TagWrapper<THelper>,
        ISmallCreator<THelper>,
        ILabelCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IHeading : ITag
    {
    }

    public abstract class Heading<THelper, TThis, TWrapper> : Tag<THelper, TThis, TWrapper>, IHeading, IHasTextContent
        where THelper : BootstrapHelper<THelper>
        where TThis : Heading<THelper, TThis, TWrapper>
        where TWrapper : HeadingWrapper<THelper>, new()
    {
        internal string SmallText { get; set; }

        internal Heading(IComponentCreator<THelper> creator, string tagName)
            : base(creator, tagName)
        {
        }


        protected override void OnStart(TextWriter writer)
        {
            // Add the appropriate CSS class if in a media object
            if(GetComponent<IMediaBody>() != null)
            {
                this.AddCss(Css.MediaHeading);
            }

            // Add the appropriate CSS class if in a list group item
            if(GetComponent<IListGroupItem>() != null)
            {
                this.AddCss(Css.ListGroupItemHeading);
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(SmallText))
            {
                new Small<THelper>(Helper).SetText(SmallText).StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }

    public class Heading<THelper> : Heading<THelper, Heading<THelper>, HeadingWrapper<THelper>>
        where THelper : BootstrapHelper<THelper>
    {
        internal Heading(IComponentCreator<THelper> creator, string tagName)
            : base(creator, tagName)
        {
        }
    }
}
