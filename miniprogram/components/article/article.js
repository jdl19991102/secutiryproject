// pages/article/article.js
Page({
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this.getNewsDetail(options.newsid)
  },
  getNewsDetail(newsid) {
    wx.request({
      url: 'https://test-miniprogram.com/api/news/detail',
      data: {
        id: newsid,
      },
      success: (res) => {
        let newsArticle = res.data.result
        let newsDate = new Date(newsArticle.date)
        let sourceText = (newsArticle.source == "") ? "未知来源" : newsArticle.source
        let dateText = `${newsDate.getFullYear()}-${newsDate.getMonth()}-${newsDate.getDate()} ${newsDate.getHours()}:${(newsDate.getMinutes() < 10 ? '0' : '') + newsDate.getMinutes()}`
        
        let news = {
          title: newsArticle.title,
          date: dateText,
          source: sourceText,
          content: newsArticle.content,
          readCount: newsArticle.readCount
        }

        this.setData({
          news: news
        })
      }
    })
  }
})