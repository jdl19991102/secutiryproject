//index.js
var sliderWidth = 42; // 设置slider的宽度，用于计算中间位置（为了在不同设备间的适配，其值需和 weui-navbar__slider 的 width 相同，且单位均为 px ，原因是下面代码使用的是 wx.getSystemInfo 获得的设备数据，即 res.windowWidth 使用 px 单位）

const newsTypeMap = {
  '大势预测': 'gn',
  '市场研究': 'gj',
  '投资策略': 'cj',
 
}

Page({
  data: {
    tabs: ['大势预测', '市场研究', '投资策略'],
    activeIndex: 0,
    sliderOffset: 0,
    sliderLeft: 0,
    newsList: []
  },
  
  onLoad: function () {
    var that = this;
    this.getNewsData();
  },
  getNewsData: function () {
    let newsList = []
    for (let i = 0; i < this.data.tabs.length; i += 1) {
      let newsTypeCN = this.data.tabs[i];
      let newsTypeID = newsTypeMap[newsTypeCN];
      newsList.push({
        typeCN: newsTypeCN,
        typeID: newsTypeID,
        newsInfo: []
      })
    }
    
    this.setData({
      newsList: newsList
    })

    let currentPage = this.data.newsList[this.data.activeIndex]
   
    this.getNewsDataOfType(currentPage.typeID)
  },
  getNewsDataOfType(newsType, completeCallback) {
    wx.request({
      url: 'https://test-miniprogram.com/api/news/list',
      data: {
        type: newsType,
      },
      success: (res) => {
        
        // 更新指定新闻类型的数据 - 对应的是当前页面的新闻数据
        let currentPageNewsList = []
        let news = res.data.result
        let defaultImagePath = "/images/list.png"
        for (let i = 0; i < news.length; i += 1) {
          let formatDate = new Date(news[i].date)
          let dateText = `${formatDate.getFullYear()}-${formatDate.getMonth()}-${formatDate.getDate()}`
          let sourceText = (news[i].source == "") ? "未知来源" : news[i].source
          let imagePath = (news[i].firstImage == "") ? defaultImagePath : news[i].firstImage
          currentPageNewsList.push({
            title: news[i].title,
            date: dateText,
            source: sourceText,
            imagePath: imagePath,
            id: news[i].id
          })
         
        }
        
        let currentPageIndex = this.data.activeIndex
        let settingArraySTR = `newsList[${currentPageIndex}].newsInfo`
        let settingFrontPageSTR = `newsList[${currentPageIndex}].frontPage`
        
        this.setData({
          [settingArraySTR]: currentPageNewsList.slice(0, news.length-1),
          [settingFrontPageSTR]: currentPageNewsList[news.length - 1]
        })
       
      },
      complete: () => {
        //第一个假返回第一个后面不执行
        completeCallback && completeCallback()
      }
    })
  },
  tabClick(e) {

    let that=this;
   
   
    this.setData({
      activeIndex:e.detail.name
    });
   
    // 判断当前页面是否有数据，有数据就不再调用 API，除非用户下拉刷新
    let currentPage = this.data.newsList[this.data.activeIndex]
    
    if (currentPage.newsInfo.length === 0) { // 此判断空数组的逻辑虽不严谨但已足够，这是 JS 语言的垃圾性决定的
      this.getNewsDataOfType(currentPage.typeID);
    }
    wx.showToast({
      title: `切换到标签 ${e.detail.name}`,
      icon: 'none',
    });
  },
  tabToNavigate: function (event) {
    let currentPage = this.data.newsList[this.data.activeIndex]
    let targetID = event.target.dataset.id
    let newsID = (targetID === -1) ? currentPage.frontPage.id: currentPage.newsInfo[targetID].id
    wx.navigateTo({
      url: '/components/article/article?newsid=' + newsID
    })
  },
  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {
    let currentPage = this.data.newsList[this.data.activeIndex]
    this.getNewsDataOfType(currentPage.typeID, function () {
      wx.stopPullDownRefresh()
    })
  }
});
