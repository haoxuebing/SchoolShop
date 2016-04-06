

function switchActive(self) {

  var li = document.querySelectorAll('li.Choice_li');

  // 删除所有 active
  for (var i=0; i<li.length; i++) {
    li[i].className = 'Choice_li';
  }

  if (self.className == 'Choice_li') {
    self.className = 'Choice_li active';
  } else {
    self.className = 'Choice_li';
  }
}
