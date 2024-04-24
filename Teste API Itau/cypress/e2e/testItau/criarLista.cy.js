import LoginHomePage from '../e2e/testItau/loginHome'


LoginHomePage.visit();

describe('Criar Lista de Itens',()=>{

    it('Navegar Até Seção de Criar Lista', ()=>{

       cy.get('botaoEditarCriar').click()
       cy.url().expect('INSIRA URL DE EDIÇÃO AQUI')

    })

    it('Criar Lista', ()=>[

        cy.get('botaoEditarEditar').click(),
        cy.contains('tabelaEditar'),
        cy.url().expect('INSIRA URL DE SUCESSO AQUI'),
        cy.get('botaoInicio').click()
    ])
})
