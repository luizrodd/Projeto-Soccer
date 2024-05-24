import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-news',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './news.component.html',
})
export class NewsComponent implements OnInit {
  news = [
    {
      id: 1,
      title: 'Title 1',
      description:
        'Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja de tipos e os embaralhou para fazer um livro de modelos de tipos. Lorem Ipsum sobreviveu não só a cinco séculos, como também ao salto para a editoração eletrônica, permanecendo essencialmente inalterado. Se popularizou na década de 60, quando a Letraset lançou decalques contendo passagens de Lorem Ipsum, e mais recentemente quando passou a ser integrado a softwares de editoração eletrônica como Aldus PageMaker.',
      image:
        'https://i.pinimg.com/originals/71/a8/f4/71a8f448849449fb0c432e0de1614ba1.jpg',
      date: '2024-05-24',
      source: 'Source 1',
      teamId: '1',
    },
    {
      id: 2,
      title: 'Title 1',
      description: 'Description 1',
      image:
        'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSaiomtAowfxOESBHK2LCIDCQEMfX3JC8P_5AAgdH_4Eg&s',
      date: '2024-05-24',
      source: 'Source 1',
      teamId: '1',
    },
    {
      id: 3,
      title: 'Title 1',
      description: 'Description 1',
      image:
        'https://media.vasco.com.br/static/2022/05/IMG-20220506-WA0035-1280x550.jpg',
      date: '2024-05-24',
      source: 'Source 1',
      teamId: '1',
    },
    {
      id: 4,
      title: 'Title 1',
      description: 'Description 1',
      image:
        'https://media.vasco.com.br/static/2022/05/IMG-20220506-WA0035-1280x550.jpg',
      date: '2024-05-24',
      source: 'Source 1',
      teamId: '1',
    },
    {
      id: 5,
      title: 'Title 1',
      description: 'Description 1',
      image:
        'https://media.vasco.com.br/static/2022/05/IMG-20220506-WA0035-1280x550.jpg',
      date: '2024-05-24',
      source: 'Source 1',
      teamId: '1',
    },
  ];

  constructor() {}

  ngOnInit() {}
}
