!function(n){var t={mode:"horizontal",slideSelector:"",infiniteLoop:!0,hideControlOnEnd:!1,speed:500,easing:null,slideMargin:0,startSlide:0,randomStart:!1,captions:!1,ticker:!1,tickerHover:!1,adaptiveHeight:!1,adaptiveHeightSpeed:500,video:!1,useCSS:!0,preloadImages:"visible",responsive:!0,slideZIndex:50,wrapperClass:"bx-wrapper",touchEnabled:!0,swipeThreshold:50,oneToOneTouch:!0,preventDefaultSwipeX:!0,preventDefaultSwipeY:!1,ariaLive:!0,ariaHidden:!0,keyboardEnabled:!1,pager:!0,pagerType:"full",pagerShortSeparator:" / ",pagerSelector:null,buildPager:null,pagerCustom:null,controls:!0,nextText:"Next",prevText:"Prev",nextSelector:null,prevSelector:null,autoControls:!1,startText:"Start",stopText:"Stop",autoControlsCombine:!1,autoControlsSelector:null,auto:!1,pause:4e3,autoStart:!0,autoDirection:"next",stopAutoOnClick:!1,autoHover:!1,autoDelay:0,autoSlideForOnePage:!1,minSlides:1,maxSlides:1,moveSlides:0,slideWidth:0,shrinkItems:!1,onSliderLoad:function(){return!0},onSlideBefore:function(){return!0},onSlideAfter:function(){return!0},onSlideNext:function(){return!0},onSlidePrev:function(){return!0},onSliderResize:function(){return!0}};n.fn.bxSlider=function(r){if(0===this.length)return this;if(this.length>1)return this.each(function(){n(this).bxSlider(r)}),this;var u={},f=this,k=n(window).width(),d=n(window).height();if(!n(f).data("bxSlider")){var g=function(){n(f).data("bxSlider")||(u.settings=n.extend({},t,r),u.settings.slideWidth=parseInt(u.settings.slideWidth),u.children=f.children(u.settings.slideSelector),u.children.length<u.settings.minSlides&&(u.settings.minSlides=u.children.length),u.children.length<u.settings.maxSlides&&(u.settings.maxSlides=u.children.length),u.settings.randomStart&&(u.settings.startSlide=Math.floor(Math.random()*u.children.length)),u.active={index:u.settings.startSlide},u.carousel=u.settings.minSlides>1||u.settings.maxSlides>1,u.carousel&&(u.settings.preloadImages="all"),u.minThreshold=u.settings.minSlides*u.settings.slideWidth+(u.settings.minSlides-1)*u.settings.slideMargin,u.maxThreshold=u.settings.maxSlides*u.settings.slideWidth+(u.settings.maxSlides-1)*u.settings.slideMargin,u.working=!1,u.controls={},u.interval=null,u.animProp="vertical"===u.settings.mode?"top":"left",u.usingCSS=u.settings.useCSS&&"fade"!==u.settings.mode&&function(){for(var i=document.createElement("div"),t=["WebkitPerspective","MozPerspective","OPerspective","msPerspective"],n=0;n<t.length;n++)if(void 0!==i.style[t[n]])return u.cssPrefix=t[n].replace("Perspective","").toLowerCase(),u.animProp="-"+u.cssPrefix+"-transform",!0;return!1}(),"vertical"===u.settings.mode&&(u.settings.maxSlides=u.settings.minSlides),f.data("origStyle",f.attr("style")),f.children(u.settings.slideSelector).each(function(){n(this).data("origStyle",n(this).attr("style"))}),ht())},ht=function(){var t=u.children.eq(u.settings.startSlide);f.wrap('<div class="'+u.settings.wrapperClass+'"><div class="bx-viewport"><\/div><\/div>');u.viewport=f.parent();u.settings.ariaLive&&!u.settings.ticker&&u.viewport.attr("aria-live","polite");u.loader=n('<div class="bx-loading" />');u.viewport.prepend(u.loader);f.css({width:"horizontal"===u.settings.mode?1e3*u.children.length+215+"%":"auto",position:"relative"});u.usingCSS&&u.settings.easing?f.css("-"+u.cssPrefix+"-transition-timing-function",u.settings.easing):u.settings.easing||(u.settings.easing="swing");u.viewport.css({width:"100%",overflow:"hidden",position:"relative"});u.viewport.parent().css({maxWidth:at()});u.children.css({float:"horizontal"===u.settings.mode?"left":"none",listStyle:"none",position:"relative"});u.children.css("width",nt());"horizontal"===u.settings.mode&&u.settings.slideMargin>0&&u.children.css("marginRight",u.settings.slideMargin);"vertical"===u.settings.mode&&u.settings.slideMargin>0&&u.children.css("marginBottom",u.settings.slideMargin);"fade"===u.settings.mode&&(u.children.css({position:"absolute",zIndex:0,display:"none"}),u.children.eq(u.settings.startSlide).css({zIndex:u.settings.slideZIndex,display:"block"}));u.controls.el=n('<div class="bx-controls" />');u.settings.captions&&wt();u.active.last=u.settings.startSlide===o()-1;u.settings.video&&f.fitVids();("all"===u.settings.preloadImages||u.settings.ticker)&&(t=u.children);u.settings.ticker?u.settings.pager=!1:(u.settings.controls&&yt(),u.settings.auto&&u.settings.autoControls&&pt(),u.settings.pager&&vt(),(u.settings.controls||u.settings.autoControls||u.settings.pager)&&u.viewport.after(u.controls.el));ct(t,lt)},ct=function(t,i){var r=t.find('img:not([src=""]), iframe').length,u=0;return 0===r?void i():void t.find('img:not([src=""]), iframe').each(function(){n(this).one("load error",function(){++u===r&&i()}).each(function(){this.complete&&n(this).trigger("load")})})},lt=function(){if(u.settings.infiniteLoop&&"fade"!==u.settings.mode&&!u.settings.ticker){var t="vertical"===u.settings.mode?u.settings.minSlides:u.settings.maxSlides,i=u.children.slice(0,t).clone(!0).addClass("bx-clone"),r=u.children.slice(-t).clone(!0).addClass("bx-clone");u.settings.ariaHidden&&(i.attr("aria-hidden",!0),r.attr("aria-hidden",!0));f.append(i).prepend(r)}u.loader.remove();tt();"vertical"===u.settings.mode&&(u.settings.adaptiveHeight=!0);u.viewport.height(c());f.redrawSlider();u.settings.onSliderLoad.call(f,u.active.index);u.initialized=!0;u.settings.responsive&&n(window).bind("resize",b);u.settings.auto&&u.settings.autoStart&&(o()>1||u.settings.autoSlideForOnePage)&&gt();u.settings.ticker&&ni();u.settings.pager&&v(u.settings.startSlide);u.settings.controls&&ft();u.settings.touchEnabled&&!u.settings.ticker&&ii();u.settings.keyboardEnabled&&!u.settings.ticker&&n(document).keydown(et)},c=function(){var r=0,t=n(),f;if("vertical"===u.settings.mode||u.settings.adaptiveHeight)if(u.carousel)for(f=1===u.settings.moveSlides?u.active.index:u.active.index*s(),t=u.children.eq(f),i=1;i<=u.settings.maxSlides-1;i++)t=f+i>=u.children.length?t.add(u.children.eq(i-1)):t.add(u.children.eq(f+i));else t=u.children.eq(u.active.index);else t=u.children;return"vertical"===u.settings.mode?(t.each(function(){r+=n(this).outerHeight()}),u.settings.slideMargin>0&&(r+=u.settings.slideMargin*(u.settings.minSlides-1))):r=Math.max.apply(Math,t.map(function(){return n(this).outerHeight(!1)}).get()),"border-box"===u.viewport.css("box-sizing")?r+=parseFloat(u.viewport.css("padding-top"))+parseFloat(u.viewport.css("padding-bottom"))+parseFloat(u.viewport.css("border-top-width"))+parseFloat(u.viewport.css("border-bottom-width")):"padding-box"===u.viewport.css("box-sizing")&&(r+=parseFloat(u.viewport.css("padding-top"))+parseFloat(u.viewport.css("padding-bottom"))),r},at=function(){var n="100%";return u.settings.slideWidth>0&&(n="horizontal"===u.settings.mode?u.settings.maxSlides*u.settings.slideWidth+(u.settings.maxSlides-1)*u.settings.slideMargin:u.settings.slideWidth),n},nt=function(){var t=u.settings.slideWidth,n=u.viewport.width();if(0===u.settings.slideWidth||u.settings.slideWidth>n&&!u.carousel||"vertical"===u.settings.mode)t=n;else if(u.settings.maxSlides>1&&"horizontal"===u.settings.mode){if(n>u.maxThreshold)return t;n<u.minThreshold?t=(n-u.settings.slideMargin*(u.settings.minSlides-1))/u.settings.minSlides:u.settings.shrinkItems&&(t=Math.floor((n+u.settings.slideMargin)/Math.ceil((n+u.settings.slideMargin)/(t+u.settings.slideMargin))-u.settings.slideMargin))}return t},h=function(){var n=1,t=null;return"horizontal"===u.settings.mode&&u.settings.slideWidth>0?u.viewport.width()<u.minThreshold?n=u.settings.minSlides:u.viewport.width()>u.maxThreshold?n=u.settings.maxSlides:(t=u.children.first().width()+u.settings.slideMargin,n=Math.floor((u.viewport.width()+u.settings.slideMargin)/t)):"vertical"===u.settings.mode&&(n=u.settings.minSlides),n},o=function(){var n=0,t=0,i=0;if(u.settings.moveSlides>0)if(u.settings.infiniteLoop)n=Math.ceil(u.children.length/s());else for(;t<u.children.length;)++n,t=i+h(),i+=u.settings.moveSlides<=h()?u.settings.moveSlides:h();else n=Math.ceil(u.children.length/h());return n},s=function(){return u.settings.moveSlides>0&&u.settings.moveSlides<=h()?u.settings.moveSlides:h()},tt=function(){var n,t,i;u.children.length>u.settings.maxSlides&&u.active.last&&!u.settings.infiniteLoop?"horizontal"===u.settings.mode?(t=u.children.last(),n=t.position(),e(-(n.left-(u.viewport.width()-t.outerWidth())),"reset",0)):"vertical"===u.settings.mode&&(i=u.children.length-u.settings.minSlides,n=u.children.eq(i).position(),e(-n.top,"reset",0)):(n=u.children.eq(u.active.index*s()).position(),u.active.index===o()-1&&(u.active.last=!0),void 0!==n&&("horizontal"===u.settings.mode?e(-n.left,"reset",0):"vertical"===u.settings.mode&&e(-n.top,"reset",0)))},e=function(t,i,r,o){var s,h;u.usingCSS?(h="vertical"===u.settings.mode?"translate3d(0, "+t+"px, 0)":"translate3d("+t+"px, 0, 0)",f.css("-"+u.cssPrefix+"-transition-duration",r/1e3+"s"),"slide"===i?(f.css(u.animProp,h),0!==r?f.bind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd",function(t){n(t.target).is(f)&&(f.unbind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd"),a())}):a()):"reset"===i?f.css(u.animProp,h):"ticker"===i&&(f.css("-"+u.cssPrefix+"-transition-timing-function","linear"),f.css(u.animProp,h),0!==r?f.bind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd",function(t){n(t.target).is(f)&&(f.unbind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd"),e(o.resetValue,"reset",0),l())}):(e(o.resetValue,"reset",0),l()))):(s={},s[u.animProp]=t,"slide"===i?f.animate(s,r,u.settings.easing,function(){a()}):"reset"===i?f.css(u.animProp,t):"ticker"===i&&f.animate(s,r,"linear",function(){e(o.resetValue,"reset",0);l()}))},it=function(){for(var r="",i="",f=o(),t=0;t<f;t++)i="",u.settings.buildPager&&n.isFunction(u.settings.buildPager)||u.settings.pagerCustom?(i=u.settings.buildPager(t),u.pagerEl.addClass("bx-custom-pager")):(i=t+1,u.pagerEl.addClass("bx-default-pager")),r+='<div class="bx-pager-item"><a href="" data-slide-index="'+t+'" class="bx-pager-link">'+i+"<\/a><\/div>";u.pagerEl.html(r)},vt=function(){u.settings.pagerCustom?u.pagerEl=n(u.settings.pagerCustom):(u.pagerEl=n('<div class="bx-pager" />'),u.settings.pagerSelector?n(u.settings.pagerSelector).html(u.pagerEl):u.controls.el.addClass("bx-has-pager").append(u.pagerEl),it());u.pagerEl.on("click touchend","a",dt)},yt=function(){u.controls.next=n('<a class="bx-next" href="">'+u.settings.nextText+"<\/a>");u.controls.prev=n('<a class="bx-prev" href="">'+u.settings.prevText+"<\/a>");u.controls.next.bind("click touchend",rt);u.controls.prev.bind("click touchend",ut);u.settings.nextSelector&&n(u.settings.nextSelector).append(u.controls.next);u.settings.prevSelector&&n(u.settings.prevSelector).append(u.controls.prev);u.settings.nextSelector||u.settings.prevSelector||(u.controls.directionEl=n('<div class="bx-controls-direction" />'),u.controls.directionEl.append(u.controls.prev).append(u.controls.next),u.controls.el.addClass("bx-has-controls-direction").append(u.controls.directionEl))},pt=function(){u.controls.start=n('<div class="bx-controls-auto-item"><a class="bx-start" href="">'+u.settings.startText+"<\/a><\/div>");u.controls.stop=n('<div class="bx-controls-auto-item"><a class="bx-stop" href="">'+u.settings.stopText+"<\/a><\/div>");u.controls.autoEl=n('<div class="bx-controls-auto" />');u.controls.autoEl.on("click",".bx-start",bt);u.controls.autoEl.on("click",".bx-stop",kt);u.settings.autoControlsCombine?u.controls.autoEl.append(u.controls.start):u.controls.autoEl.append(u.controls.start).append(u.controls.stop);u.settings.autoControlsSelector?n(u.settings.autoControlsSelector).html(u.controls.autoEl):u.controls.el.addClass("bx-has-controls-auto").append(u.controls.autoEl);y(u.settings.autoStart?"stop":"start")},wt=function(){u.children.each(function(){var t=n(this).find("img:first").attr("title");void 0!==t&&(""+t).length&&n(this).append('<div class="bx-caption"><span>'+t+"<\/span><\/div>")})},rt=function(n){n.preventDefault();u.controls.el.hasClass("disabled")||(u.settings.auto&&u.settings.stopAutoOnClick&&f.stopAuto(),f.goToNextSlide())},ut=function(n){n.preventDefault();u.controls.el.hasClass("disabled")||(u.settings.auto&&u.settings.stopAutoOnClick&&f.stopAuto(),f.goToPrevSlide())},bt=function(n){f.startAuto();n.preventDefault()},kt=function(n){f.stopAuto();n.preventDefault()},dt=function(t){var i,r;t.preventDefault();u.controls.el.hasClass("disabled")||(u.settings.auto&&u.settings.stopAutoOnClick&&f.stopAuto(),i=n(t.currentTarget),void 0!==i.attr("data-slide-index")&&(r=parseInt(i.attr("data-slide-index")),r!==u.active.index&&f.goToSlide(r)))},v=function(t){var i=u.children.length;return"short"===u.settings.pagerType?(u.settings.maxSlides>1&&(i=Math.ceil(u.children.length/u.settings.maxSlides)),void u.pagerEl.html(t+1+u.settings.pagerShortSeparator+i)):(u.pagerEl.find("a").removeClass("active"),void u.pagerEl.each(function(i,r){n(r).find("a").eq(t).addClass("active")}))},a=function(){if(u.settings.infiniteLoop){var n="";0===u.active.index?n=u.children.eq(0).position():u.active.index===o()-1&&u.carousel?n=u.children.eq((o()-1)*s()).position():u.active.index===u.children.length-1&&(n=u.children.eq(u.children.length-1).position());n&&("horizontal"===u.settings.mode?e(-n.left,"reset",0):"vertical"===u.settings.mode&&e(-n.top,"reset",0))}u.working=!1;u.settings.onSlideAfter.call(f,u.children.eq(u.active.index),u.oldIndex,u.active.index)},y=function(n){u.settings.autoControlsCombine?u.controls.autoEl.html(u.controls[n]):(u.controls.autoEl.find("a").removeClass("active"),u.controls.autoEl.find("a:not(.bx-"+n+")").addClass("active"))},ft=function(){1===o()?(u.controls.prev.addClass("disabled"),u.controls.next.addClass("disabled")):!u.settings.infiniteLoop&&u.settings.hideControlOnEnd&&(0===u.active.index?(u.controls.prev.addClass("disabled"),u.controls.next.removeClass("disabled")):u.active.index===o()-1?(u.controls.next.addClass("disabled"),u.controls.prev.removeClass("disabled")):(u.controls.prev.removeClass("disabled"),u.controls.next.removeClass("disabled")))},gt=function(){u.settings.autoDelay>0?setTimeout(f.startAuto,u.settings.autoDelay):(f.startAuto(),n(window).focus(function(){f.startAuto()}).blur(function(){f.stopAuto()}));u.settings.autoHover&&f.hover(function(){u.interval&&(f.stopAuto(!0),u.autoPaused=!0)},function(){u.autoPaused&&(f.startAuto(!0),u.autoPaused=null)})},ni=function(){var o,c,s,a,i,h,r,t,v=0;"next"===u.settings.autoDirection?f.append(u.children.clone().addClass("bx-clone")):(f.prepend(u.children.clone().addClass("bx-clone")),o=u.children.first().position(),v="horizontal"===u.settings.mode?-o.left:-o.top);e(v,"reset",0);u.settings.pager=!1;u.settings.controls=!1;u.settings.autoControls=!1;u.settings.tickerHover&&(u.usingCSS?(a="horizontal"===u.settings.mode?4:5,u.viewport.hover(function(){c=f.css("-"+u.cssPrefix+"-transform");s=parseFloat(c.split(",")[a]);e(s,"reset",0)},function(){t=0;u.children.each(function(){t+="horizontal"===u.settings.mode?n(this).outerWidth(!0):n(this).outerHeight(!0)});i=u.settings.speed/t;h="horizontal"===u.settings.mode?"left":"top";r=i*(t-Math.abs(parseInt(s)));l(r)})):u.viewport.hover(function(){f.stop()},function(){t=0;u.children.each(function(){t+="horizontal"===u.settings.mode?n(this).outerWidth(!0):n(this).outerHeight(!0)});i=u.settings.speed/t;h="horizontal"===u.settings.mode?"left":"top";r=i*(t-Math.abs(parseInt(f.css(h))));l(r)}));l()},l=function(n){var r,o,s,h=n?n:u.settings.speed,t={left:0,top:0},i={left:0,top:0};"next"===u.settings.autoDirection?t=f.find(".bx-clone").first().position():i=u.children.first().position();r="horizontal"===u.settings.mode?-t.left:-t.top;o="horizontal"===u.settings.mode?-i.left:-i.top;s={resetValue:o};e(r,"ticker",h,s)},ti=function(t){var u=n(window),i={top:u.scrollTop(),left:u.scrollLeft()},r=t.offset();return i.right=i.left+u.width(),i.bottom=i.top+u.height(),r.right=r.left+t.outerWidth(),r.bottom=r.top+t.outerHeight(),!(i.right<r.left||i.left>r.right||i.bottom<r.top||i.top>r.bottom)},et=function(n){var t=document.activeElement.tagName.toLowerCase(),i=new RegExp(t,["i"]),r=i.exec("input|textarea");if(null==r&&ti(f)){if(39===n.keyCode)return rt(n),!1;if(37===n.keyCode)return ut(n),!1}},ii=function(){u.touch={start:{x:0,y:0},end:{x:0,y:0}};u.viewport.bind("touchstart MSPointerDown pointerdown",ri);u.viewport.on("click",".bxslider a",function(n){u.viewport.hasClass("click-disabled")&&(n.preventDefault(),u.viewport.removeClass("click-disabled"))})},ri=function(n){if(u.controls.el.addClass("disabled"),u.working)n.preventDefault(),u.controls.el.removeClass("disabled");else{u.touch.originalPos=f.position();var t=n.originalEvent,i="undefined"!=typeof t.changedTouches?t.changedTouches:[t];u.touch.start.x=i[0].pageX;u.touch.start.y=i[0].pageY;u.viewport.get(0).setPointerCapture&&(u.pointerId=t.pointerId,u.viewport.get(0).setPointerCapture(u.pointerId));u.viewport.bind("touchmove MSPointerMove pointermove",p);u.viewport.bind("touchend MSPointerUp pointerup",w);u.viewport.bind("MSPointerCancel pointercancel",ot)}},ot=function(){e(u.touch.originalPos.left,"reset",0);u.controls.el.removeClass("disabled");u.viewport.unbind("MSPointerCancel pointercancel",ot);u.viewport.unbind("touchmove MSPointerMove pointermove",p);u.viewport.unbind("touchend MSPointerUp pointerup",w);u.viewport.get(0).releasePointerCapture&&u.viewport.get(0).releasePointerCapture(u.pointerId)},p=function(n){var r=n.originalEvent,t="undefined"!=typeof r.changedTouches?r.changedTouches:[r],o=Math.abs(t[0].pageX-u.touch.start.x),s=Math.abs(t[0].pageY-u.touch.start.y),f=0,i=0;3*o>s&&u.settings.preventDefaultSwipeX?n.preventDefault():3*s>o&&u.settings.preventDefaultSwipeY&&n.preventDefault();"fade"!==u.settings.mode&&u.settings.oneToOneTouch&&("horizontal"===u.settings.mode?(i=t[0].pageX-u.touch.start.x,f=u.touch.originalPos.left+i):(i=t[0].pageY-u.touch.start.y,f=u.touch.originalPos.top+i),e(f,"reset",0))},w=function(n){u.viewport.unbind("touchmove MSPointerMove pointermove",p);u.controls.el.removeClass("disabled");var r=n.originalEvent,o="undefined"!=typeof r.changedTouches?r.changedTouches:[r],i=0,t=0;u.touch.end.x=o[0].pageX;u.touch.end.y=o[0].pageY;"fade"===u.settings.mode?(t=Math.abs(u.touch.start.x-u.touch.end.x),t>=u.settings.swipeThreshold&&(u.touch.start.x>u.touch.end.x?f.goToNextSlide():f.goToPrevSlide(),f.stopAuto())):("horizontal"===u.settings.mode?(t=u.touch.end.x-u.touch.start.x,i=u.touch.originalPos.left):(t=u.touch.end.y-u.touch.start.y,i=u.touch.originalPos.top),!u.settings.infiniteLoop&&(0===u.active.index&&t>0||u.active.last&&t<0)?e(i,"reset",200):Math.abs(t)>=u.settings.swipeThreshold?(t<0?f.goToNextSlide():f.goToPrevSlide(),f.stopAuto()):e(i,"reset",200));u.viewport.unbind("touchend MSPointerUp pointerup",w);u.viewport.get(0).releasePointerCapture&&u.viewport.get(0).releasePointerCapture(u.pointerId)},b=function(){if(u.initialized)if(u.working)window.setTimeout(b,10);else{var t=n(window).width(),i=n(window).height();k===t&&d===i||(k=t,d=i,f.redrawSlider(),u.settings.onSliderResize.call(f,u.active.index))}},st=function(n){var t=h();u.settings.ariaHidden&&!u.settings.ticker&&(u.children.attr("aria-hidden","true"),u.children.slice(n,n+t).attr("aria-hidden","false"))},ui=function(n){return n<0?u.settings.infiniteLoop?o()-1:u.active.index:n>=o()?u.settings.infiniteLoop?0:u.active.index:n};return f.goToSlide=function(t,i){var y,p,w,b,h=!0,k=0,r={left:0,top:0},l=null;if(u.oldIndex=u.active.index,u.active.index=ui(t),!u.working&&u.active.index!==u.oldIndex){if(u.working=!0,h=u.settings.onSlideBefore.call(f,u.children.eq(u.active.index),u.oldIndex,u.active.index),"undefined"!=typeof h&&!h)return u.active.index=u.oldIndex,void(u.working=!1);"next"===i?u.settings.onSlideNext.call(f,u.children.eq(u.active.index),u.oldIndex,u.active.index)||(h=!1):"prev"===i&&(u.settings.onSlidePrev.call(f,u.children.eq(u.active.index),u.oldIndex,u.active.index)||(h=!1));u.active.last=u.active.index>=o()-1;(u.settings.pager||u.settings.pagerCustom)&&v(u.active.index);u.settings.controls&&ft();"fade"===u.settings.mode?(u.settings.adaptiveHeight&&u.viewport.height()!==c()&&u.viewport.animate({height:c()},u.settings.adaptiveHeightSpeed),u.children.filter(":visible").fadeOut(u.settings.speed).css({zIndex:0}),u.children.eq(u.active.index).css("zIndex",u.settings.slideZIndex+1).fadeIn(u.settings.speed,function(){n(this).css("zIndex",u.settings.slideZIndex);a()})):(u.settings.adaptiveHeight&&u.viewport.height()!==c()&&u.viewport.animate({height:c()},u.settings.adaptiveHeightSpeed),!u.settings.infiniteLoop&&u.carousel&&u.active.last?"horizontal"===u.settings.mode?(l=u.children.eq(u.children.length-1),r=l.position(),k=u.viewport.width()-l.outerWidth()):(y=u.children.length-u.settings.minSlides,r=u.children.eq(y).position()):u.carousel&&u.active.last&&"prev"===i?(p=1===u.settings.moveSlides?u.settings.maxSlides-s():(o()-1)*s()-(u.children.length-u.settings.maxSlides),l=f.children(".bx-clone").eq(p),r=l.position()):"next"===i&&0===u.active.index?(r=f.find("> .bx-clone").eq(u.settings.maxSlides).position(),u.active.last=!1):t>=0&&(b=t*parseInt(s()),r=u.children.eq(b).position()),"undefined"!=typeof r?(w="horizontal"===u.settings.mode?-(r.left-k):-r.top,e(w,"slide",u.settings.speed)):u.working=!1);u.settings.ariaHidden&&st(u.active.index*s())}},f.goToNextSlide=function(){if(u.settings.infiniteLoop||!u.active.last){var n=parseInt(u.active.index)+1;f.goToSlide(n,"next")}},f.goToPrevSlide=function(){if(u.settings.infiniteLoop||0!==u.active.index){var n=parseInt(u.active.index)-1;f.goToSlide(n,"prev")}},f.startAuto=function(n){u.interval||(u.interval=setInterval(function(){"next"===u.settings.autoDirection?f.goToNextSlide():f.goToPrevSlide()},u.settings.pause),u.settings.autoControls&&n!==!0&&y("stop"))},f.stopAuto=function(n){u.interval&&(clearInterval(u.interval),u.interval=null,u.settings.autoControls&&n!==!0&&y("start"))},f.getCurrentSlide=function(){return u.active.index},f.getCurrentSlideElement=function(){return u.children.eq(u.active.index)},f.getSlideElement=function(n){return u.children.eq(n)},f.getSlideCount=function(){return u.children.length},f.isWorking=function(){return u.working},f.redrawSlider=function(){u.children.add(f.find(".bx-clone")).outerWidth(nt());u.viewport.css("height",c());u.settings.ticker||tt();u.active.last&&(u.active.index=o()-1);u.active.index>=o()&&(u.active.last=!0);u.settings.pager&&!u.settings.pagerCustom&&(it(),v(u.active.index));u.settings.ariaHidden&&st(u.active.index*s())},f.destroySlider=function(){u.initialized&&(u.initialized=!1,n(".bx-clone",this).remove(),u.children.each(function(){void 0!==n(this).data("origStyle")?n(this).attr("style",n(this).data("origStyle")):n(this).removeAttr("style")}),void 0!==n(this).data("origStyle")?this.attr("style",n(this).data("origStyle")):n(this).removeAttr("style"),n(this).unwrap().unwrap(),u.controls.el&&u.controls.el.remove(),u.controls.next&&u.controls.next.remove(),u.controls.prev&&u.controls.prev.remove(),u.pagerEl&&u.settings.controls&&!u.settings.pagerCustom&&u.pagerEl.remove(),n(".bx-caption",this).remove(),u.controls.autoEl&&u.controls.autoEl.remove(),clearInterval(u.interval),u.settings.responsive&&n(window).unbind("resize",b),u.settings.keyboardEnabled&&n(document).unbind("keydown",et),n(this).removeData("bxSlider"))},f.reloadSlider=function(t){void 0!==t&&(r=t);f.destroySlider();g();n(f).data("bxSlider",this)},g(),n(f).data("bxSlider",this),this}}}(jQuery)